   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:POS.View.windowsPOS.View.windows  5   	   $    POS.View.windows.wd_messageBox   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:POS.View.windows     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � WindowStyle$
  None=�5	   
    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�5
   	   $��0q�6    � Title$ Increase POS��5   
   $	��175��6   $	��300��6,   
������  � AllowsTransparency . .��5      � -   5         �Name$ 	grid_main��5   )   $��1��6   $��1��6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��* �6   .+�5   
   � .+�5      �� $��0q�6   $��0��6*    �� CornerRadius$ 7,7,0,0��5      ���#178DD2._�5      � .+�5      �� -   5         ��Name$ 	txt_title��5   /   $��warning��6    
�������$��Center=�5   $   $��Center=�6A   $��1��5      $	��5,0q�64   �� 5      -   5        	 ��Name$	 	btn_colse��5   Y   
 �� IsCancel
 . $��Right=�5   0   $��Center=�6L   
�������$��7.5,0q�5   I   $��SemiBold"�5      $��24��64   $��0q�6?    � ToolTip$ Close��6K   $��14(�6\   ��5   g   Z� ��5      Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
�������   Kind$ Close=�6E   $��20��5   *   $��20��65   5      5      5       5!      �� 5"   
   $��1,0,1,1q�6   $��1��6,   $ 0,0,7,7��5#      ���#999999
�������._�5$      � -   5        $ grid_mainGrid��5$       5%      �� 5&      $��* �6$   �� 5'      $
��auto �6$   .+�5)      �� $��0��6   $��2��6)   ���#737373$
��Bold"�6r   $��14(�6�   $
��Wrap=�5*       �� TextAlignment$ Center=�6*   $��Center=�6B   $��Center=�6^   $��5q�5+      ��5)   >   �� *contentText2+5+      �� 5,      -   5        $	 btn_ok��5-   (   $��1��5,      $��Ok��6*   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 7��67   $��10,7.5q�5-      ���#178DD2��5.   0   Z� 50      51      52      53      