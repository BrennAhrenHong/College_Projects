#include <Wire.h>
#include<LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27,16,2);
float val = 0;

void setup() {
  lcd.init();
  lcd.backlight();
  lcd.setCursor(2,0);
  lcd.print("Voltage Value:");
}

void loop() {
  PotentioLcd();
}

void PotentioLcd()
{
  val = analogRead(A0);
  val = val/1024*5.0;

  lcd.setCursor(6,1);

  lcd.print(val);
  lcd.print("V");
  delay(200);
}
