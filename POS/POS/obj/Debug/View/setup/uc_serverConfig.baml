   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:POS.View.setupPOS.View.setup  5      $    POS.View.setup.uc_serverConfig   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:POS.View.setup     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	txt_title��5   )   $��Server Config��6   ���#178DD2$��2��5   
   $
��Bold"�6   $��18(�60   $��Center=�6A   $
��Left=�5      $��
10,10,10,5q�64   �� 5   
   $��1��6   $��3��6   $��5 0 5 5q�64   $��2��6J   $��0q�5         MainColorlightGrey#��[  6&   �� 5   
   -   5        $ txt_serverUriTitle��5      $��Server Uri:��60   $��14(�6C   $
��Left=�5      $��5q�6/     MainColorGrey#��[ 5       $��2��5!      $��0��6$   $��Center=�5"      �� 5#   
   -   5         ��Name$ tb_serverUri��5#      $�� ��6(   $��10,0,5,0q�60   $��2��5$      $��1��6(   $��0,0,0,2q�5%      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Server Uri��60    % !MaterialDesignFloatingHintTextBox#��[ 5&   '   #��[ 5'   &   $��12(�6S   ���#f8f8f8
�������$��40��5*   &   $��5q�62   .  (MaterialDesignThemes.Wpf.TextFieldAssist   CharacterCounterStyle 5)   &   �� .��5,   L   5-      F� 5.   
   -   5         F�Name$ p_errorServerUri��5.   A   ���#E81123 �� Stretch$
 Fill=�6   $��
0,15,15,15q�6-   $��Right=�5/   #   $��1��6?   $��2��6R   $y�	Collapsed=�6`   $��Center=�50   #   $��15��6>   $��15��6J   ����� � �� Ӏ�b �� �� ��b ��  � Ӏ� �U��b ��O � ��OӀU��O��O�U��O � Ӏ�O��b �U��  � �� � � @]� Ӑ�� @]� �ا p� �ا  � ��ا  z ��ا ��q ��� ��j  � ��j �p� ��j @]� ��q @]�  z �@]�  � �@]� p� p� @]�  � @]� �@]� @f��ا @f��ا ��� �@]� ��� �@]� @f	 � ToolTip 52      _� 53      -   5        	 _�Name$	 tt_errorServerUri��53      $�� ��66     ToolTipError#��[ 6B   55      �� 59   
   -   5        $ txt_activationkeyTitle��59      $��Activation key:��64   $��14(�6K   $
��Left=�5:      $��5q�6/   #��[ 5;      $��3��5<      $��0��6$   $��Center=�5=      �� 5>   
   -   5        $ tb_activationkey��5>      $�� ��6,   $��10,0,5,0q�64   $��3��5?      $��1��6(   $��0,0,0,2q�5@      $ Activation key��60   #��[ 5A   '   #��[ 5B   &   $��12(�6S   ���#f8f8f8
�������
 �� 	MaxLength$
 20��5D   &   $��40��5E   &   $��5q�62    5D   5   �� .��5G   L   5H      F� 5I   
   -	   5        $ p_errorActivationkey��5I   A   ���#E81123$
 Fill=�6   $��
0,15,15,15q�6-   $��Right=�5J   #   $��1��6?   $��3��6Q   $y�	Collapsed=�6_   $��Center=�5K   #   $��15��6>   $��15��6J   ����� � �� Ӏ�b �� �� ��b ��  � Ӏ� �U��b ��O � ��OӀU��O��O�U��O � Ӏ�O��b �U��  � �� � � @]� Ӑ�� @]� �ا p� �ا  � ��ا  z ��ا ��q ��� ��j  � ��j �p� ��j @]� ��q @]�  z �@]�  � �@]� p� p� @]�  � @]� �@]� @f��ا @f��ا ��� �@]� ��� �@]� @f	 5M      _� 5N      -
   5        $	 tt_errorActivationkey��5N      #��[ 6;   5P      5S      5T      