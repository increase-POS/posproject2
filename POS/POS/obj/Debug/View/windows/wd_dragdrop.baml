   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:POS.View.windowsPOS.View.windows  5   	   "    POS.View.windows.wd_dragdrop   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:POS.View.windows     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Increase POS��5   
   $	��500��6    $	��200��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   6.   �� 5      $	��100 �6   6.   �� 5      $	��100 �6   6.   �� 5      $	��100 �6   6.   �� 5      $��50 �6   6-   .+�5   
   �� -   5         ��Name$
 txt1��5   !   $��0��6   $
��txt1��6/   $��25q�6;    �� Padding$ 10q�6G   
�������$��Center=�6f    J� 	AllowDrop . 6�   �� 5   
   -   5        $
 txt2��5   !   $��1��6   $
��txt2��6/   $��25q�6;   $ 10q�6G   
�������$��Center=�6f    . 6�   �� 5   
   -   5        $
 txt3��5   !   $��2��6   $
��txt3��6/   $��25q�6;   $ 10q�6G   
�������$��Center=�6f    . 6�   � 5   
   -   5         �Name$ 	grid_drag��5      $��3��6   
����  �.+�5      �� $��grid1��6   5      � 5   
   -   5        $ 	grid_drop��5      $��4��6   
����� � . .+�5      �� $��grid2��6   5      5      5      