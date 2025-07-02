import sys
from datetime import datetime, timedelta
from lunardate import LunarDate
from ics import Calendar, Event

def read_input_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as f:
        lines = [line.strip() for line in f if line.strip()]

    num_years = int(lines[0][1:])
    num_years = min(max(num_years, 2), 20)
    events = []

    for line in lines[1:]:
        date_part, title = line.split(':', 1)
        day, month = date_part.strip().split('/')
        events.append((day.strip(), int(month.strip()), title.strip()))

    return num_years, events

def lunar_to_solar(year, month, day):
    if day == 'e':
        day = last_day_of_lunar_month(year, month)
    else:
        day = int(day)

    try:
        return LunarDate(year, month, day).toSolarDate()
    except ValueError:
        # Handle leap months if needed
        return LunarDate(year, month, day, leap=True).toSolarDate()

def last_day_of_lunar_month(year, month):
    # Check lunar month length
    for day in [30, 29]:
        try:
            LunarDate(year, month, day)
            return day
        except ValueError:
            continue
    return 29  # default

def create_calendar(num_years, events):
    calendar = Calendar()
    current_year = datetime.now().year

    for offset in range(num_years):
        year = current_year + offset
        for day, month, title in events:
            solar_date = lunar_to_solar(year, month, day)
            e = Event()
            e.name = title
            e.begin = solar_date.strftime('%Y-%m-%d')
            e.make_all_day()
            calendar.events.add(e)

    return calendar

def main():
    input_file = 'input.txt'
    output_file = 'output.ics'

    num_years, events = read_input_file(input_file)
    calendar = create_calendar(num_years, events)

    with open(output_file, 'w', encoding='utf-8') as f:
        f.writelines(calendar.serialize())

    print(f"✅ Đã tạo thành công {output_file}")

if __name__ == '__main__':
    main()
