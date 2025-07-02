<?php
require 'Lunar.php';

// Xử lý input
$data = $_POST['events'] ?? '';
$lines = explode("\n", trim($data));

$num_years = (int) substr(array_shift($lines), 1);
$num_years = max(2, min($num_years, 20));
$events = [];

foreach ($lines as $line) {
    list($date, $title) = explode(':', $line);
    list($day, $month) = explode('/', trim($date));
    $events[] = [trim($day), (int)$month, trim($title)];
}

// Khởi tạo lịch ICS
$ics = "BEGIN:VCALENDAR\r\nVERSION:2.0\r\nCALSCALE:GREGORIAN\r\n";

// Xử lý sự kiện
$currentYear = date('Y');

for ($i = 0; $i < $num_years; $i++) {
    $year = $currentYear + $i;

    foreach ($events as $event) {
        list($day, $month, $title) = $event;

        if ($day === 'e') {
            $day = Lunar::getLastDayOfMonth($year, $month);
        }

        $solarDate = Lunar::convertLunar2Solar($day, $month, $year);
        $dateString = date('Ymd', strtotime($solarDate));

        $ics .= "BEGIN:VEVENT\r\n";
        $ics .= "SUMMARY:{$title}\r\n";
        $ics .= "DTSTART;VALUE=DATE:{$dateString}\r\n";
        $ics .= "DTEND;VALUE=DATE:{$dateString}\r\n";
        $ics .= "END:VEVENT\r\n";
    }
}

$ics .= "END:VCALENDAR";

// Xuất file .ics
header('Content-Type: text/calendar; charset=utf-8');
header('Content-Disposition: attachment; filename="output.ics"');
echo $ics;
exit;
