   M S B A M L   `   `   `  ����J  FCarRentalSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CarRentalSystemCarRentalSystem  5   	        CarRentalSystem.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CarRentalSystem     5   	     � Title$  Login - Car Rental System��5   	   $	��500��6+   $	��800��68    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6Z   ���	#FF547E76.��5	      �  � RowDefinitions 5
   
   �� 5      $	��59* �6   �� 5      $
��330* �6   �� 5      $	��82* �6   .+�5   
   �� $
��Left=�6   $��50��60   $��21,0,0,0q�6<   $	��Top=�6N   $	��760��6f   �� 5   
   $
��Left=�6   $	��328��60   $��
295,14,0,0q�6=   $��1��6Q   $	��Top=�6^   $	��460��6v    �� Orientation$ Vertical=�6�   $��2��6�   .+�5      �� -   5         ��Name$ tbLogin��5      $
��Wrap=�6)   $��45��6=   $��20(�6I   $��100,5,136,0q�6W   $��LOGIN��6l   �� 5      -   5        $ 
tbUsername��5      $
��Wrap=�6,   $��username��6@   $��20��6P   $��100,10,100,0q�6\   �� 5      -   5         ��Name$ txtUsername��5      $��40��6+    �� TextWrapping$
 Wrap=�67   $��
100,0,0,10q�6K   $��15(�6_   $��DengXian)�6m   $	��350��6�   $
��Left=�6�   $
��0,10q�6�   �� 5      -   5        $ 
tbPassword��5      $
��Wrap=�6,   $��password��6@   $��20��6P   $��100,20,100,0q�6\   G� 5      -   5         G�Name$ txtPassword��5      $��40��6/   $	��350��6;   $��
100,0,0,10q�6G   $
��Left=�6[   	 G� PasswordChar$	 *��6v   $
��0,10q�6�   $��15(�6�   �� 5      $��80��6   $��140,10,50,0q�6%   $ 
Horizontal=�6:   .+�5      �� -   5        
 ��Name$
 btnLogin��5      $��LogIn��6+   $	��195��6;   $��40��6G   $��
30,20,0,20q�6S   ���	#FFDAD0D06~   5      5      �� 5   
   $
��Left=�6   $	��100��6/   $��0,5,0,0q�6<   $��2��6M   $	��Top=�6^   $	��792��6v    J� RenderTransformOrigin$ 0.545,0.578&�6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $	��215��6:   $��	80,61,0,0q�6G   $��1��6Z   $	��Top=�6g   $	��215��6   $��Assets/user.png��6�   �� 5   
   -   5        $ 	textBlock��5      $
��Left=�6'   $��	240,5,0,0q�6B   $
��Wrap=�6U   $��STAMMY CARS��6i   $	��Top=�6|   $��55��6�   $��2��6�   $	��270��6�   $��40(�6�   $��Segoe WP Light)�6�   
�������6�   5      5      