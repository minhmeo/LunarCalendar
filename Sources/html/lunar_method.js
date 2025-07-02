// Constants
const LOCAL_TIMEZONE = 7.0;

// Helper functions
function INT(d) {
    return Math.floor(d);
}

function MOD(x, y) {
    let z = x - y * INT(x / y);
    return z === 0 ? y : z;
}

function UniversalToJD(D, M, Y) {
    let JD;
    if (Y > 1582 || (Y == 1582 && (M > 10 || (M == 10 && D > 14)))) {
        JD = 367 * Y - INT(7 * (Y + INT((M + 9) / 12)) / 4)
             - INT(3 * (INT((Y + (M - 9) / 7) / 100) + 1) / 4)
             + INT(275 * M / 9) + D + 1721028.5;
    } else {
        JD = 367 * Y - INT(7 * (Y + 5001 + INT((M - 9) / 7)) / 4)
             + INT(275 * M / 9) + D + 1729776.5;
    }
    return JD;
}

function LocalToJD(D, M, Y) {
    return UniversalToJD(D, M, Y) - LOCAL_TIMEZONE / 24.0;
}

function UniversalFromJD(JD) {
    let Z = INT(JD + 0.5);
    let F = (JD + 0.5) - Z;
    let A = Z < 2299161 ? Z : Z + 1 + INT((Z - 1867216.25) / 36524.25) - INT(INT((Z - 1867216.25) / 36524.25) / 4);
    let B = A + 1524;
    let C = INT((B - 122.1) / 365.25);
    let D = INT(365.25 * C);
    let E = INT((B - D) / 30.6001);
    let dd = INT(B - D - INT(30.6001 * E) + F);
    let mm = E < 14 ? E - 1 : E - 13;
    let yyyy = mm < 3 ? C - 4715 : C - 4716;
    return { day: dd, month: mm, year: yyyy };
}

function LocalFromJD(JD) {
    return UniversalFromJD(JD + LOCAL_TIMEZONE / 24.0);
}

function SunLongitude(jdn) {
    let T = (jdn - 2451545.0) / 36525;
    let T2 = T * T;
    let dr = Math.PI / 180;
    let M = 357.52910 + 35999.05030 * T - 0.0001559 * T2 - 0.00000048 * T * T2;
    let L0 = 280.46645 + 36000.76983 * T + 0.0003032 * T2;
    let DL = (1.914600 - 0.004817 * T - 0.000014 * T2) * Math.sin(dr * M)
           + (0.019993 - 0.000101 * T) * Math.sin(dr * 2 * M)
           + 0.000290 * Math.sin(dr * 3 * M);
    let L = (L0 + DL) * dr;
    L -= Math.PI * 2 * (INT(L / (Math.PI * 2)));
    return L;
}

function NewMoon(k) {
    let T = k / 1236.85;
    let T2 = T * T;
    let T3 = T2 * T;
    let dr = Math.PI / 180;
    let Jd1 = 2415020.75933 + 29.53058868 * k
              + 0.0001178 * T2 - 0.000000155 * T3
              + 0.00033 * Math.sin((166.56 + 132.87 * T - 0.009173 * T2) * dr);
    let M = 359.2242 + 29.10535608 * k - 0.0000333 * T2 - 0.00000347 * T3;
    let Mpr = 306.0253 + 385.81691806 * k + 0.0107306 * T2 + 0.00001236 * T3;
    let F = 21.2964 + 390.67050646 * k - 0.0016528 * T2 - 0.00000239 * T3;
    let C1 = (0.1734 - 0.000393 * T) * Math.sin(M * dr)
             + 0.0021 * Math.sin(2 * dr * M)
             - 0.4068 * Math.sin(Mpr * dr)
             + 0.0161 * Math.sin(2 * dr * Mpr)
             - 0.0004 * Math.sin(3 * dr * Mpr)
             + 0.0104 * Math.sin(2 * dr * F)
             - 0.0051 * Math.sin(dr * (M + Mpr))
             - 0.0074 * Math.sin(dr * (M - Mpr))
             + 0.0004 * Math.sin(dr * (2 * F + M))
             - 0.0004 * Math.sin(dr * (2 * F - M))
             - 0.0006 * Math.sin(dr * (2 * F + Mpr))
             + 0.0010 * Math.sin(dr * (2 * F - Mpr))
             + 0.0005 * Math.sin(dr * (2 * Mpr + M));
    let deltat = T < -11
        ? 0.001 + 0.000839 * T + 0.0002261 * T2 - 0.00000845 * T3 - 0.000000081 * T * T3
        : -0.000278 + 0.000265 * T + 0.000262 * T2;
    return Jd1 + C1 - deltat;
}

function LunarMonth11(Y) {
    let off = LocalToJD(31, 12, Y) - 2415021.076998695;
    let k = INT(off / 29.530588853);
    let jd = NewMoon(k);
    let ret = LocalFromJD(jd);
    let sunLong = SunLongitude(LocalToJD(ret.day, ret.month, ret.year));
    if (sunLong > 3 * Math.PI / 2) jd = NewMoon(k - 1);
    return LocalFromJD(jd);
}

// Main function Lunar → Solar
function lunarToSolar(lDay, lMonth, lYear, leap = 0) {
    let yy = lMonth >= 11 ? lYear + 1 : lYear;
    let month11 = LunarMonth11(yy - 1);
    let jdMonth11 = LocalToJD(month11.day, month11.month, month11.year);
    let k = INT(0.5 + (jdMonth11 - 2415021.076998695) / 29.530588853);
    let nm = NewMoon(k + lMonth - 1 + leap);
    let solarDate = LocalFromJD(nm + lDay - 1);
    return solarDate;
}

// Example usage:
let solarDate = lunarToSolar(10, 3, 2025);
console.log(`Solar Date: ${solarDate.day}/${solarDate.month}/${solarDate.year}`);
