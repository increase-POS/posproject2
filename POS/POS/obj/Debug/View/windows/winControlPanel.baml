   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:POS.View.windowsPOS.View.windows  5   	   &     POS.View.windows.winControlPanel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      *localclr-namespace:POS.View.windows  5   	   -   5          � Title$  Increase POS��5   	    � WindowStyle$
 None=�5   
    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�5   	   $��0,0,0,0q�6   $	��450��5      $	��300��6   
������  � AllowsTransparency . $��RightToLeft=�5       .��5      � -   5         �Name$ 	grid_main��5   )   $��1��6   $��1��6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��60 �6   .+�5   
   �� $��0q�6   $��0��6&    �� CornerRadius$ 7,7,0,0��5      ���#178DD2._�5      � .+�5      �� $��Center=�6   $��Center=�6:    �� Orientation$ 
Horizontal=�6V   .+�5      �� -   5        	 ��Name$	 txt_settings��5   ,   $��Settings��6   
�������$	��5,0q�5   !   '  !MaterialDesignThemes.Wpf.PackIcon  5      
�������
   Kind$
 Settings=�6=   $��15��6M   $��15��6Y   6f   5       �� 5"      -   5         ��Name$ 
btn_cancel��5"      $��Right=�6B   
������ $��0q�6w   
������ .��5#        $
 Close=�6*   69   5$      5%      5&      �� 5'   
   $��1��6   
�������._�5(      �� $��20q�6   $��Disabled=�6"   ��6V   �� *	TheList+��5)      �� 5+      .R�5,      ��  d� 	IsChecked 6'   �� *
IsSelected+��6H   �� *	TheText+5-      ��50      �� 51      .R�52      �  � Orientation$ Vertical=�6$   53      55      56      �� 58   
   
�������$��2��6$   $ 0,0,7,7��61   ._�5:      �� -   5        $ btn_ok��5:         MainColorBlue#��[  6)   $��Stretch=�6U   $
��10,0q�6�   $��Ok��6�   6�   5<      5=      5>      