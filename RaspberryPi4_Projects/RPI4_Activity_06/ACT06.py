import I2C_LCD_driver
import time

mylcd = I2C_LCD_driver.lcd()

while True:
		mylcd.lcd_display_string("Hello world!", 2, 3)
		time.sleep(1)
		mylcd.lcd_clear()
		time.sleep(1)