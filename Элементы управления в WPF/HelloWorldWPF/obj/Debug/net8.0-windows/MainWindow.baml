   M S B A M L   `   `   `  ����  HelloWorldWPF    HelloWorldWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          �Name$  MyWindow��5   	   
������� � Title$ Калькулятор��5      $	��600��5      $	��612��6   .��5	      � $��0,0,0,-6q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$
 Btn1��5      $��1��6   $��128,266,118,266q�6+   $��18(�6D   6R   �� 5   
   -   5        $
 Btn2��5      $��2��6   $��193,266,64,266q�6+   $��18(�6C   6Q   �� 5   
   -   5        $
 Btn3��5      $��3��6   $��247,266,10,266q�6+   $��18(�6C   6Q   �� 5   
   -   5        $
 Btn4��5      $��4��6   $��301,266,261,266q�6+   $��18(�6D   $��2��6e   �� 5   
   -   5        $
 Btn5��5      $��5��6   $��50,266,204,266q�6+   $��18(�6C   $��1��6d   �� 5   
   -   5        $
 Btn6��5      $��6��6   $��107,266,147,266q�6+   $��18(�6D   $��1��6e   �� 5   
   -   5        $
 Btn7��5      $��7��6   $��128,329,118,203q�6+   $��18(�6D   6R   �� 5   
   -	   5        $
 Btn8��5      $��8��6   $��193,329,64,203q�6+   $��18(�6C   6Q   �� 5   
   -
   5        $
 Btn9��5      $��9��6   $��247,329,10,203q�6+   $��18(�6C   6Q   �� 5   
   -   5        $
 Btn0��5      $��0��6   $��302,329,261,203q�6+   $��18(�6D   $��2��6e   �� 5   
   -   5        $
 CBtn��5      $��C��6   $��50,329,204,203q�6+   $��18(�6C   $��1��6d   �� 5   
   -   5        $ EqualBtn��5      $��=��6#   $��107,329,147,203q�6/   $��18(�6H   $��1��6m   �� 5   
   -   5        $ PlusBtn��5      $��+��6"   $��128,392,118,140q�6.   $��18(�6G   6U   �� 5   
   -   5        $ MinusBtn��5      $��-��6#   $��193,392,64,140q�6/   $��18(�6G   6U   �� 5   
   -   5        $ MultyplyBtn��5      $��*��6&   $��247,392,10,140q�62   $��18(�6J   6X   �� 5   
   -   5        $ DivBtn��5      $��/��6!   $��301,392,261,140q�6-   $��18(�6F    J� RenderTransformOrigin$ 	1.755,0.5&�6T   $��2��6�   �� 5   
   -   5         ��Name$ Display��5      $
��Left=�6%   $	��148��6@   $��
128,88,0,0q�6M   $
��Wrap=�6a   $	��Top=�6u   $	��337��6�   
���   �$��Arial Black)�6�   $��22(�6�   $
��Bold"�6�   $��2��6�    �� 
LineHeight$ 10��6�   $�� ��6	  $ 0.5,0&�6  ���	#FFA4FFBF6/  �� 5   
   -   5        $ FloatBtn��5      $��.��6#   $��0,392,204,140q�6/   $��18(�6F   $��1��6k   $��Right=�6{   $��52��6�   $ 	0.3,0.483&�6�   �� 5    
   -   5        $ 
BracketBtn��5       $	��( )��6%   $��107,392,147,140q�63   $��18(�6L   $��1��6Z   6j   �� 5!   
   -   5        $ HistoryText��5!      $��2��6)   $
��Left=�6=   $��74��6X   $��	0,506,0,0q�6d   $
��Wrap=�6w   $	��Top=�6�   $	��612��6�   �� 6�    � Language$ ru-ru�6�   $*�$ История вычислений��6�   �� 6�   $	�:  ��6�   6�   5"      5#      