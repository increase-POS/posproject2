   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:POS.View.windowsPOS.View.windows  5   	   "    POS.View.windows.wd_userInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:POS.View.windows     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
   -   5          � Title$  Increase POS��5   	    � WindowStyle$
 None=�5
   
    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�5   	   $��0q�6   $	��175��5   
   $	��500��6   
������  � AllowsTransparency . .��5      � -   5         �Name$ 	grid_main��5   +   $��1��6   $��1��6   .+�5   
   �� $	��2.5q�6   $��1��6(    �� CornerRadius$ 7��5         MainColorBlue#��[  6&   
�������._�5      � $��5q�6    � RowDefinitions 5      �� 5      $��25 �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $��* �6'   .+�5       �� -   5        	 ��Name$	 	btn_colse��5"   U   $��2��5       $��5��6*   
 �� IsCancel
 . $��Right=�5!      $	��Top=�65   
�������$��0q�5"   I   $��SemiBold"�5#      $��0q�65    � ToolTip$ Close��6A   $��14(�6R   ��5!   M   Z� ��5"      Z� .��5$      '  !MaterialDesignThemes.Wpf.PackIcon  ���#8C8C8C   Kind$ Close=�6C   $��20��5%   *   $��20��65   5&      �� 5(      -   5         ��Name$ bdr_mainImage��5(   ,   $��5��6   $��10q�6C   $��LeftToRight=�5)   Y   ��6   ��  �� Path$ ActualHeight� �� ElementName$ bdr_mainImage����5*      �� 5+       j� Stretch$ Uniform=�6'    �� ImageSource$$ /pic/no-image-icon-125x125.png��6:   5-      �� 5.      $��5��6   $��1��6,   $
��5,20q�6=   $��2��5/      $��0q�6$     MainColorlightGrey#��[ 68   �� 50      -   5         ��Name$ txt_userNameTitle��50       $��1��6;   $��2��6H   $��5q�6Y   $
��Left=�51       $��
User Name:��6;   $��16(�6M   $��SemiBold"�52   !   #��[  53      $��Center=�54      �� 55      -   5        $ txt_userName��55   ;   $��1��6   $��3��6+   $��16(�6S   $��SemiBold"�56      $
��Left=�65   $��5q�6P   ���#8C8C8C$��Center=�58      �� 5:      -   5        $ txt_posTitle��5;      $��2��5:      $��2��6)   $��5q�6:   $
��Left=�5;   5   $
��Pos:��6P   $��16(�6\   $��SemiBold"�5<   !   #��[  5=      $��Center=�5>      �� 5?      -   5        $ txt_pos��5?   ;   $��2��6   $��3��6+   $��16(�6L   $��SemiBold"�5@      $
��Left=�65   $��5q�6P   ���#8C8C8C$��Center=�5B      �� 5D      -	   5        $ txt_branchTitle��5F       $��3��5D      $��2��6)   $��5q�6:   $
��Left=�5E       $��Branch:��6;   $��16(�6J   $��SemiBold"�5F   :   #��[  5G      $��Center=�5H      �� 5I      -
   5        $ 
txt_branch��5I   ;   $��3��6   $��3��6+   $��16(�6O   $��SemiBold"�5J      $
��Left=�65   $��5q�6P   ���#8C8C8C$��Center=�5L      5N      5P      5S      5T      