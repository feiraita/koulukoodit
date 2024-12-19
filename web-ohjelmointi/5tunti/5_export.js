const INCH_TO_CM = 2.54;

export function inchesToCm(inch) {
    return inch * INCH_TO_CM;
}

export function cmToInches(cm) {
    return cm / INCH_TO_CM;
}