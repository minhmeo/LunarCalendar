// Thuật toán âm lịch (nguồn: thư viện lunar-javascript, tối giản)
// có thể sử dụng bản đầy đủ tại: https://github.com/6tail/lunar-javascript
// <script src="https://cdn.jsdelivr.net/npm/lunar-javascript/lunar.min.js"></script>
// Ví dụ dùng thư viện lunar-javascript chính xác:
// function lunar2solar(year, month, day) {
//    const solar = Lunar.fromYmd(year, month, day).getSolar();
//    return {year: solar.getYear(), month: solar.getMonth(), day: solar.getDay()};
// }

// function getLunarMonthLength(year, month) {
//    return Lunar.fromYm(year, month).getDayCount();
// }

function lunar2solar(year, month, day) {
    let lunar = new Date(Lunar.toSolar(year, month, day));
    return {year: lunar.getFullYear(), month: lunar.getMonth() + 1, day: lunar.getDate()};
}

function getLunarMonthLength(year, month) {
    return Lunar.getDaysOfMonth(year, month);
}

// Lunar library (rút gọn)
const Lunar = {
    toSolar: function(y, m, d){
        return LunarDateConverter.lunarToSolar(y,m,d);
    },
    getDaysOfMonth: function(y, m){
        return LunarDateConverter.getLunarMonthDays(y, m);
    }
};

// (Minimal library for Lunar Conversion)
const LunarDateConverter = {
    lunarToSolar: function(y,m,d){
        const lunar = new Date(y, m-1, d); // simplified placeholder
        lunar.setDate(lunar.getDate() + 29); // rough estimate (replace by accurate library for production)
        return lunar;
    },
    getLunarMonthDays: function(y, m){
        return 29; // simple placeholder, replace by accurate lunar month calculator if needed
    }
};
