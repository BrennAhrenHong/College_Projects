#include <Wire.h>
#include<LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27,16,2);
float val = 0;

const int ledRed = 7;
const int ledYellow = 6;
const int ledGreen = 5;

void setup() {

  pinMode(ledGreen, OUTPUT);
  pinMode(ledYellow, OUTPUT);
  pinMode(ledRed, OUTPUT);
  
  lcd.init();
  lcd.backlight();
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
  lcd.setCursor(2,0);
  lcd.print("Voltage Value:");

  if(val >= 1.67)
    digitalWrite(ledRed, HIGH);
  else
    digitalWrite(ledRed, LOW);

  if(val >= 3.33)
    digitalWrite(ledYellow, HIGH);
  else
    digitalWrite(ledYellow, LOW);

  if(val >= 4.98)
    digitalWrite(ledGreen, HIGH);
  else
    digitalWrite(ledGreen, LOW);

  delay(200);
}
