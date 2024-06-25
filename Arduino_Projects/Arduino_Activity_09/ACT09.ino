#include <Wire.h>
#include<LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd (0x27,16,2);

void setup() {
lcd.init();
lcd.backlight();
}

void loop() {
lcd.setCursor(7,0);
lcd.print("Hello World!");
lcd.setCursor(7,1);
lcd.print("How r u Today?:)");
}
