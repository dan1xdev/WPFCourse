   M S B A M L   `   `   `  ����@  <Laba8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba8Laba8  5   	       Laba8.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba8     5   	   -   5        $��myWindow��5	   	     � Title$  Блокнот��5   	   $	��450��6   $	��800��6&   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� -   5        $��MainMenu��5   %   $��Файл��6   .@�5      m� -   5        $��
NewFileBtn��5      $��
Новый��6-    m� Command$ ApplicationCommands.New��6<   m� 5      -   5        $��OpenFileBtn��5      $��Открыть...��6.   $ ApplicationCommands.Open��6B   m� 5      -   5        $��SaveFileBtn��5      $��Сохранить��6.   $ ApplicationCommands.Save��6A   �� 5      m� 5      -   5        $��ExitBtn��5      $��
Выход��6+   6:   5      m� 5      -   5        $��EditMenu��5   '   $��Правка��6   .@�5      m� -   5        $��CopyBtn��5      $��Копировать��6*   $ ApplicationCommands.Copy��6>   m� 5      -	   5        $��PasteBtn��5      $��Вставить��6+   $ ApplicationCommands.Paste��6=   m� 5      -
   5        $��CutBtn��5      $��Вырезать��6)   $ ApplicationCommands.Cut��6;   5      5      �� 5   
   -   5         ��Name$ 
myCombobox��5       $��1��6   $��Center=�64   $��0,0,0,0q�6Q   $	��Top=�6b   $	��790��6z   $��25��6�   $��Center=�6�   .@�5      �� $��Русский��6   
 � Tag$ ru��6-   �� 5       $��English��6   $ en��6-   5!      �� 5"   
   -   5         ��Name$ TextArea��5"      $��2��6$    �� AcceptsReturn .  �� 
AcceptsTab . " �� VerticalScrollBarVisibility$
 Auto=�5%   
   $	 �� HorizontalScrollBarVisibility$
	 Auto=�5&   
   5'      5(      