   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:POS.View.windowsPOS.View.windows  5   	   !    POS.View.windows.wd_serials   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:POS.View.windows     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  Increase POS��5   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�5   	   $��0q�6   $	��135��5   	   $	��300��6   ���#333333.��5      � -   5         �Name$ 	grid_main��5   ?   $��1��6   $��2��6   ���#333333 � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��* �6   .+�5   
   � ���#333333.+�5      �� $��0q�6   $��0��6*    �� CornerRadius$ 7,7,0,0��5      ���#178DD2._�5      � .+�5      �� -   5         ��Name$ 	btn_colse��5   Y    �� IsCancel . $��Right=�5   /   $��Center=�6K   
�������$��7.5,0q�5   I   $��SemiBold"�5      $��24��64   $��0q�6?   $��14(�6L   ��5   f   Z� ��5      Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
�������	   Kind$	 Close=�6E   $��20��5   *   $��20��65   
 � ToolTip
 5      _� 5   "   -   5         _�Name$ tt_close��5   *    _� 	Placement$
 left=�6<    _� HorizontalOffset$ 5��6M    _� PlacementRectangle$ 50,0,0,0�5   .    _� VerticalOffset$ 20��6L   5!      5"      � 5#      $��Center=�6    � ColumnDefinitions 5$      �� 5%      $��* �6/   �� 5&      $
��1.2* �6/   .+�5(      F� 
������� �� Stretch$
 Fill=�6,   $	��5,0q�6;   $��Right=�5)      $��0��6;   $��Center=�5*      $��15��6:   $��15��6E   �����@[l Ǡ�@[l�H+�5F � ��43333�V@S  �������T@@��ō`�gffffFQ@S`Js    �P@ �743333�O@���    @O@S@-�43333�N@���    �N@���    �N@S��    �N@ �b    �N@������n@    �N@S ������̌N@������n@gffff�N@ ��gffff�N@�����In@gfffffO@ �I43333�P@ �I@zA� �I`c1 �I�L! �I�5
� �I��= �I�gj �I �� �I`N�@^] ��������S Z�43333sm@`=�  ��43333�m@S�z'43333�m@�����|t@43333�m@`��43333�m@�����w@    �m@�����w@� ����@�G�d@[l�$�@[lgfffffl@�@[l H<��j@��@[l Ǡ�  ��@�	�r ��e q��� �O@���ǆ��� L�@��S���gffff�V@gffff�t@ ec�N9gffff�V@S��q43333�V@@H����@H�43333X@S ;�    �Y@@H������l[@@H�43333]@S@H�43333�^@@H�gffffF`@@H�gffff&a@S@H�    �a@��z��m 2P    �a@S`A643333�a@`�43333�a@��43333�a@S ��43333�a@�������̌a@���43333a@S���43333C`@���������^@��������L]@S���hfffff\@ �    �[@ zW�����\@S �C�����,\@�T1�����L\@`~    `\@������s@    �\@������s@433333\@������s@����̬[@�@j��\�w���/  �������qp@�\S���gffffFY@�� y�43333q@���S��tgffff�V@����̄q@ �o    �q@�-t������Dr@�U}������r@�^�gffff�r@@�)� �`ln@O	`��gffff�r@`� �gffff�r@@P643333�r@`�ngffff�r@����    �r@ � ϰ� R`�M��v�gffff�q@�6�gffff�q@`����k`S{����U^fffff�p@ �" �� ���fffffVp@�3M �@�������qp@�\�@�����S �������i@�U���v��d�;����" G�gffff�q@�a�`���,�S /*�����|j@��������	j@�D������)i@S ������)h@ ���	�������f@S@��������d@��.�����9d@@��233333d@S@4R�����/d@�b�����̬d@@��effff�e@S�' �����<f@������r@������f@�������yg@S@O	�����yg@�\�����yg@ ������|g@�`���n�' ���@��������`�S�i������ii@gffff�u@ �Y@}������9j@� �K�ͼ@��������j@�u�������j@S :+23333sj@gffff�s@effff�i@gffff�s@�����i@S�������,h@��233333g@    �s@�����9f@����̬s@������e@gffff�s@ �
������s@������d@�����4t@�����\d@hffff~t@effff6d@hffff�t@233333d@�����Yu@�����,d@53333�u@����̬d@53333�u@������e@    v@233333f@�����v@������f@     v@�����lg@�`�@�h�g�
���`����(@Ό
���#@dt
`�`fW
�R�`1K
�  ���8
 ��������e@�1�`�o
Ӏ��`o�
�ԉ��
�ԉ@A�
� N���. ���z�u� #���u�@e� �����1� c�Ӏf�`�@�� ��G�`�@��`���S`������	i@� �& ���&0�����|h@ 43���������1u@��k��4`�K��4�����lg@S`A6�����lg@ �7�����lg@@�:�����lg@���4`�
��1���
��(@Ό
��|
 �`
�������q@@[7
`�@[7
����b
�`P��
 C������Lf@`~ 6�
������Iq@`C�
`~@��
`~���
������Iq@���
 {�����9g@��y �4������Dq@ �4@zv �4�����Aq@�-6�`~ �q�����Oq@ ���j�������h@S��������Li@������q@�����ii@ J������\i@S�:�23333Si@��� @����E`��������q@�����Yh@������q@ �q�`)��)������q@���
������q@��
� S`:�
��@dt
�|
 �`
��� +����� )��	���� ��������`@S �������`@ ������|`@`������<`@S �*effffF_@gffff�q@�����^@gffff�q@effff�\@43333�q@233333\@�m$������[@��effff[@S`�23333�Z@@+efffffZ@ ������Z@S`b����̬Y@ ������Y@`�������yY@S �23333sY@�&�23333�Y@ x������Z@gffffVq@����̌Z@��|�����[@��|13333�[@S {13333�\@43333Kq@�����L^@gffffNq@����̬_@��5��� ׋@b��� +�	5+      �� 5@      -   5         ��Name$ 	txt_title��5@   2   $��Serial��6$   
�������$
��Left=�5A   $   $��Center=�6?   $��1��5B      $	��5,0q�64   5C      5D      5E      5F      �� 5G   
   $��1,0,1,1q�6   $��2��6,   $ 0,0,7,7��5H      ���#999999
�������._�5I      � -   5        $ grid_mainGrid��5I       5J      �� 5K      $��* �6$   �� 5L      $��* �6$   .+�5N      �� -   5         ��Name$ 	tb_serial��5N      $��0��6-   $��	10,5,10,5q�6:   $��0,0,0,2q�5O   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Serial...��6<   ���#4E4E4E$��12(�5P   8   ���#f8f8f8
������� �� 	MaxLength$ 20��5Q   :   $y�Visible=�6I   $��35��5S   "   $��	10,5,10,5q�6/   $��2��6B   .  (MaterialDesignThemes.Wpf.TextFieldAssist   CharacterCounterStyle 5R   "   �� 5S   B   F� 5T      -   5         F�Name$ p_errorSerial��5T   &   ���#E81123$
 Fill=�6=   $��5,5,15,5q�6L   $��Right=�5U      $��0��6;   $y�	Collapsed=�6H   $��Center=�5V      $��15��65   $��15��6A   ����� � �� Ӏ�b �� �� ��b ��  � Ӏ� �U��b ��O � ��OӀU��O��O�U��O � Ӏ�O��b �U��  � �� � � @]� Ӑ�� @]� �ا p� �ا  � ��ا  z ��ا ��q ��� ��j  � ��j �p� ��j @]� ��q @]�  z �@]�  � �@]� p� p� @]�  � @]� �@]� @f��ا @f��ا ��� �@]� ��� �@]� @f	
 5X      _� 5Y      -	   5        $ tt_errorSerial��5Y   "   $��Name Not Validate��6:      ToolTipError#��[  6W   5[      �� 5\      -
   5        $ btn_save��5]   (   $��1��5\      $
��Save��6*   $��10,2.5q�5]      ���#178DD2��5^   0   Z� 5_      5`      5a      5b      