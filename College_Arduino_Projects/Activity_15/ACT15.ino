void setup() {
  // put your setup code here, to run once:
  pinMode(13,OUTPUT); // Set built-in LED output
  pinMode(2,INPUT); // Set built-in LED output
}

void loop() {
  // put your main code here, to run repeatedly:
  int digitalVal = digitalRead(2);

  if(digitalVal == HIGH)
    digitalWrite(13,LOW);
   else
    digitalWrite(13,HIGH);
}
