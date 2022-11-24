library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_unsigned.all;
entity smartHome is 
port(
rfid : in std_logic;
laser,button: in std_logic;
button2:in   std_logic;
led,led2 :buffer std_logic :='0';
openMotor : out std_logic);
end smartHome;
architecture arch of smartHome is
signal m :std_logic :='0';
signal n :std_logic :='0';
begin 
process(rfid,laser,button)
begin
  if rfid = '1'  then
		openMotor<= '1';
  else
  if button='0' then
	openMotor<= '1';
  else
	  openMotor<= '0';
  end if;
  end if;
  if button2='1' then
	led2<='1';
	else
	led2<='0';
	end if;
  if laser='0' then
		led<='1';
		else
		led<='0';
	end if;

end process;

end arch;

