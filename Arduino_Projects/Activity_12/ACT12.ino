#include <Wire.h>
#include<LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd (0x27,16,2);

const int passiveBuzzerPin = 12;
const int activeBuzzerPin = 11;
const int buttonOne = 6;
const int buttonTwo = 7;

int counter = 0;
int buttonOneState = LOW;
int buttonTwoState = LOW;

void setup() {
  // put your setup code here, to run once:
  pinMode(passiveBuzzerPin,OUTPUT);
  pinMode(activeBuzzerPin, OUTPUT);
  pinMode(buttonOne, INPUT);
  pinMode(buttonTwo, INPUT);

  
  lcd.init();
  lcd.backlight();
}

void loop() {
  // put your main code here, to run repeatedly:

  buttonOneState = digitalRead(buttonOne);
  buttonTwoState = digitalRead(buttonTwo);

    
 if(buttonOneState == HIGH)
 {
      lcd.clear();
      lcd.setCursor(1,0);
      lcd.print("B1 IS PRESSED");
      lcd.setCursor(1,1);
      lcd.print("PAS BUZZER ENABLED");
      counter++;
      PassiveBuzzer();
 }
  
 if( buttonTwoState == HIGH)
 {
      lcd.clear();
      lcd.setCursor(1,0);
      lcd.print("B2 IS PRESSED");
      lcd.setCursor(1,1);
      lcd.print("ACT BUZ ENABLED");
      counter++;
  ActiveBuzzer();
 }
  
 

}

void PassiveBuzzer()
{
  for(int i = 900; i<= 1000; i++)//increase frequency
  {
    tone(passiveBuzzerPin, i); //generate tone
    delay(50);
  }
    delay(1000);

  for(int i = 1000; i >= 900; i--) //decrease frequency
  {
    tone(passiveBuzzerPin, i);
    delay(50);
  }

  noTone(passiveBuzzerPin);
}

void ActiveBuzzer()
{
  for(int i = 0; i<= 20; i++)
  {
    digitalWrite(activeBuzzerPin,HIGH);
    delay(500);
    digitalWrite(activeBuzzerPin,LOW);
    delay(100);
  }
}
