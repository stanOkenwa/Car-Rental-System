   M S B A M L   `   `   `  ����J  FCarRentalSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRentalSystemCarRentalSystem  5   	   #    CarRentalSystem.LandingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CarRentalSystem     5   	     � Title$  LandingWindow��5   	   $	��600��6   $
��1000��6,    � 
ResizeMode$ CanMinimize=�69    � WindowStartupLocation$ CenterScreen=�6R   ���	#FF547E76.��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��19* �6   �� 5      $
��459* �6   �� 5      $��0* �6   �� 5      $	��18* �6    � RowDefinitions 5   
   �� 5      $	��70* �6   �� 5      $
��385* �6   �� 5      $
��114* �6   .+�5   
   �� $��1��6   $��146.333��6%   $��
10,10,10,0q�66   $��1��6J   $	��Top=�6W    �� Orientation$ 
Horizontal=�6o   .+�5      �� -   5         ��Name$ 	btnAddCar��5      $	��200��6)   $��	100,0,0,0q�65   $��ADD CAR��6`   5      �� 5      -   5        $ 
btnRentCar��5      $��RENT CAR��6)   $	��200��6<   $��35,0,0,0q�6H   6Z   �� 5      -   5        $ btnModifyCar��5      $��
MODIFY CAR��6+   $	��200��6@   $��35,0,0,0q�6L   6^   5      �� 5   
   $��1��6   $��146.333��6%   $��10,0,10,30.889q�66   $��1��6N   $��Bottom=�6[   $ 
Horizontal=�6v   .+�5      �� -   5        $ btnDeleteCar��5      $��
DELETE CAR��6+   $	��200��6@   $��	200,0,0,0q�6L   6_   �� 5      -   5        $ btnSearchCar��5      $��
SEARCH CAR��6+   $	��200��6@   $��80,0,0,0q�6L   6^   5      �� 5    
   -   5        $ 	btnLogout��5       $��LogOut��6$   $��1��65   $��Right=�6E   $��
0,25,53,15q�6a   $	��100��6u   $��30��6�   6�   �� 5!   
   $
��Left=�6   $��10��6/   $��0,55,0,0q�6;   $	��Top=�6M   $	��993��6e   $��4��6q   5#      5$      