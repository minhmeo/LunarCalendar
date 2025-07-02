<?php
class Lunar {
    public static function convertLunar2Solar($lunarDay, $lunarMonth, $lunarYear, $timezone = 7) {
        $jd = self::jdFromDate($lunarDay, $lunarMonth, $lunarYear);
        return self::jdToDate($jd);
    }

    public static function getLastDayOfMonth($year, $month) {
        return self::getLunarMonthLength($month, $year);
    }

    // Các hàm phụ trợ
    private static function jdFromDate($dd, $mm, $yy) {
        $a = floor((14 - $mm) / 12);
        $y = $yy + 4800 - $a;
        $m = $mm + 12 * $a - 3;
        $jd = $dd + floor((153 * $m + 2) / 5) + 365 * $y + floor($y / 4) - floor($y / 100) + floor($y / 400) - 32045;
        return $jd;
    }

    private static function jdToDate($jd) {
        $Z = $jd;
        $A = $Z;
        $B = floor(($A - 1867216.25) / 36524.25);
        $A += 1 + $B - floor($B / 4);
        $C = $A + 1524;
        $D = floor(($C - 122.1) / 365.25);
        $E = floor(365.25 * $D);
        $F = floor(($C - $E) / 30.6001);

        $day = $C - $E - floor(30.6001 * $F);
        $month = ($F < 14) ? $F - 1 : $F - 13;
        $year = ($month > 2) ? $D - 4716 : $D - 4715;

        return "{$year}-{$month}-{$day}";
    }

    private static function getLunarMonthLength($month, $year) {
        $length = [29,30,29,30,29,30,29,30,29,30,29,30];
        return $length[($month - 1) % 12];
    }
}
