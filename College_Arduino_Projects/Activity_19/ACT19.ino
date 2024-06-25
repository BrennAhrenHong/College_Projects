void setup()
{
  pinMode(8,OUTPUT); //intialize pin as output
}

void loop()
{
  int sensorValue = analogRead(A0); //Read sensor output value at A0

  if(sensorValue <= 512)
    digitalWrite(8,LOW); //LED OFF
  else
    digitalWrite(8,HIGH); //LED ON
}
