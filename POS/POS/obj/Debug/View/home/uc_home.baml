   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:POS.ViewPOS.View  5      e aDe.TorstenMandelkow.MetroChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d5b8d1bbc99c4a2awTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	          POS.View.uc_home   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:POS.View     5      k
MetroChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5	      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5          � 	Resources  5      "  LiveCharts.Wpf.DefaultLegend �� 
TargetType   PieChartDefaultLegend �� Property �� Value#  LiveCharts.Wpf.DefaultTooltip  PieChartDefaultTooltip  LiveCharts.Wpf.PieChart&   LiveCharts.Wpf.Charts.Base.Chart �� 	Resources �� BasedOn��%  &	        &	 R     '      7   7  �� 5   
   "  6   .�5      ��  �@ 
BulletSize$ 0Q�6+   5      �� 5   
   "  6   .�5      ��  �@ SelectionMode$ 
OnlySenderX�6.   �� 5       � ��$ 2q�60   �� 5       �@ 
BulletSize$ 20Q�6+   5      �� 5   
   "  6   .�5      ��  �@ InnerRadius$
 12.5Q�6,   �� 5       �@ LegendLocation$ Right=�6/    5       ���� 5!      8   '        "  6I   �� 5"      8  '        "  6J   5#      5$      5%      .��5&      � -   5         �Name$ 	grid_main��5&      .+�5'   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5(      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5)         Kind$ FadeIn=�62   	   Duration$	 0:0:1.5h�6A     5*      $ SlideInFromRight=�62   $	 0:0:1h�6J   .��5,      � $��5q�6   ���#E8E8E8
 � RowDefinitions
 5-      �� 5.      $��* �6$   �� 5/      $��2* �6$   �� 50      $��2* �6$   �� 51      $��2* �6$   �� 52      $��2* �6$   �� 53      $��30 �6$    � ColumnDefinitions 55      �� 56      $��* �6'   �� 57      $��* �6'   �� 58      $��* �6'   �� 59      $��* �6'   �� 5:      $��* �6'   .+�5?      �� $��10q�6   $��0��6%   
������� �� CornerRadius$ 7��5@      ._�5A      � 
������  5B      �� 5C      $	��7.5 �6/   �� 5D      $��* �6/   �� 5E      $
��auto �6/   �� 5F      $��2* �6/   .+�5H      �� ���#5B5182$ 7,0,0,7��5I      F� 5J      ���#5B5182 �� Stretch$
 Fill=�6/   $��1��5K      $��LeftToRight=�6-   $��25��5L      $��25��6%   �I�����Y�,`9�-��Y�,�{�-�Y�,��-�Y�,  �-Ӏ��, sH.`W, m.@��+ �}.������E�@�!/�����}�@@�/�������@�Jo0�23333�@@1�����Y|@ [�1������x@`Y2������u@ �3�����Oq@gffff�@�����k@��\4�133333e@@��4bffff�^@�fi5����̬R@@4�5�bffffFP@��6������K@��,6������F@ ;K6�\ffff�E@ ;K6�����YD@ ;K6������B@ ;K6�����?@�����Y�@Rffff�;@`̻5�����:@`�M5�333336@���3Rffff�1@����̔�@������*@�����݉@������5@�����ԉ@������=@�����ˉ@������B@�����ĉ@������D@�������@�����E@��O1\fffffE@@�u1������F@�����M�@������G@����̬�@������H@`{�3�\fffffJ@�l4\fffffJ@�l4bffff�P@@�E4�bffff�Y@`��313333sa@��w313333f@@�3�����̌f@@�3dffff�f@@)�2������f@@ �2������f@ Y�1�����\e@@�1�����ld@�
C0������9d@��0�����d@gffff"�@03333�c@�п/������f@ i�/�����Yh@��V/03333�j@��%/�������n@`��.������q@`�c.������s@ j.������Ot@`�-������t@ 5�-�����au@�� .�effff�u@`B.23333Kv@�����%�@������v@@.�13333�v@��.�����w@�M".13333w@�.V.������'w@ �.13333Cw@�������@�����iw@@A�/�����̌w@�-�/������w@@��/�����)x@�ü/������\x@@�/�����ox@@A�/�����lx@�����͈@�dfffffx@@��.�����ax@�����g�@�����Tx@��..������Lx@���-03333[x@�����	�@����̔x@�������@dffff>z@������@03333|@�����Q�@03333�}@ �',23333�@�������@�����7�@�#U+�����X�@�������@������i�@�F�*effffz�@�F�*�������@�����|�@13333o�@������@�����k�@�������@13333w�@@I\.�����̔�@�.V.����̰�@�����I�@13333˂@�����D�@13333�@������@dffff�@�����ԇ@dffffB�@�������@������h�@�U�,�����w�@����̈�@�����o�@���,������D�@@��*������@�����p�@13333�@�����y�@�������@�x&�����ԅ@�����݃@�����Å@ RE%dffffn�@����̤�@dffff�@����̼�@�����Ȅ@ ��%��������@@1�%�������@�������@�������@�,%�����̘�@�.$����̀�@�����x�@�����h�@�������@������]�@���!effff^�@���!����̘�@����̴�@�������@�������@13333ۄ@�������@�������@����̨�@������@�������@13333;�@���!�����a�@23333��@�����W�@�����c�@�����O�@�����+�@�����E�@������@23333�@������@�����߄@dffff�}@effff��@dffff�{@�������@�����T{@23333��@13333C{@effff��@�����I{@23333;�@13333[{@������@�����i{@�������@�����y{@23333��@������z@effff��@�����Wz@����̀�@����̼y@�������@dffff�y@�����q�@�����iy@23333�@�����Qy@23333G�@�����<y@23333c�@�����qy@�����t�@�����,z@23333�@23333S�@ 3;+23333��@�����C�@�����ˆ@�����U�@13333+�@�����`�@�������@23333o�@������@�`��, V�-�ž,`�-�Y�,`9�-�c� ���@���%������,z@��� �9@����]��y��C� �� �5�����Ls@S@W������r@ ������̌r@ F� �����1r@S�!�����)r@��!�����r@��!������q@S��!����̤q@gffff^�@�j�`\"!�����q@S�i%!23333sd@�����a�@������J@�v(!hffff&L�S�v(!������O������T�@�����yP��"� ����Ӡb �Y�������؀@gffff&Q��s�gffffFQ�S`t�gffffFQ����gffffFQ�@�TgffffFQ����1 =�@������P�`��hffff�N�gffffz@hffff�M�gffff�y@������L�gffff�y@53333sK�gffff�y@133333J@    �y@ Ԅ	43333�y@������p@���� ������-��c� ��� ���ʬ�������.����������+� ��������+���I�`�.���������*������6����Ӏ�6���\ {0�fffff�p@�`*����S`�"�������o@���� �� `y�`���gfffff>�@;� ���������n@`��������n@� ��� �����������n@@�U�������n@S���������n@�&������o@@��������p@S@�������̌s@@���������v@@��������lz@S@!������az@@_U�23333[z@��������Lz@���@��q�@�# ���ʬ� � H�/������!������=�@����̌A��=l0�X���0Ӡ���`D�0`m����0������R���"0�������T� h(.�����_V���-,������W�`�1*� y���fS&23333^���s"����̌`�������@S�a��������~@ ���������}@������a�������|@S็�������|@็�������|@@3��������|@������a�13333|@�X��������{@fffff�`�������{@�����^�����̄{@������[������_{@ V�������?{@������D�13333�z@hffff�1@������y@`�������$y@S�4������Wx@�ڿ13333�w@ ��effff�v@gffffvu@effffv@ � effffNu@ �������t@S��������4t@ N�������s@gffff��@23333ss@S`�""�����_s@ |P"�����ts@gffff�@������s@S ��"23333�t@gffffJ�@������u@gffff^�@�����iv@�@\$���43333c�@fffff��@    �@�Z�$�������@43333׃@gffff�@�A�&    ,�@43333�@    8�@433337�@�����,�@�����\�@�����̃@43333o�@�����̌�@�Y)�����M�@�������@������@gffff.�@    �{@43333��@������v@gffff�@    `r@���,�@9 ��-`ֆ���. � H�/p���"fffff��@� �`�� gffff�}@ �$ L� �^(gfffff~@�����A�@�����( J�����q�@S@P������0�@ �"������@�'�$��s'Ӏ�$��S'��$@pA'@�$`�0'�gffff�@���%gffff�@ .Q$�6�#�q�"��o�#`��!`�x#43333O�@gffff~�@gffffҀ@���9# ����!#�������@���"fffff��@�@Ѕ�c�Ӏ�' �E�����g�!=�D���� ��k!43333s}@gffffʁ@��    �@��#`]�"gffffv}@43333�@ ��     �@���    �@���    ؁@ ��    ��@���������@�7)�����h�@�`��hffffb�@`JshffffV�@ g\�����0�@@�k43333?�@43333�u@63333�~@gffff&v@    �|@43333�v@�����|@43333�v@53333k{@    �v@������z@@���@Ѕ`���I�@I�@Ѕ�c�� 
`ͳӀ�	
���`(
�����E�@@�
��3� �@
`�� @  �! � <$"�gffff�k@@�K"gffff�l@@Rd"gffffn@ P�"�43333cn@@�"�����"    �n@�Ҽ"�gffff&o@���#gffff�o@�����u�@gffffp@������@S@�]�����9�@43333p@�����G�@�����yo@�����;�@������n@�����-�@    n@23333�@hffff�m@23333��@53333�l@�����Ã@     l@�������@    pk@23333C�@������j@������@������i@23333�@53333�h@effff��@����̌g@������@hffff�f@�����T�@hffff�f@����̜�@hffff�f@13333ۃ@533333g@effff�@53333�g@�����C�@53333Ci@dffffʄ@�����Ik@������@������m@dffff6�@    �n@�����@�@������o@�����C�@hffff~p@13333K�@����̄p@�����[�@53333�p@�����l�@53333�p@�����}�@    �p@�������@53333�p@13333Ӆ@hffff�p@�������@������p@�����#�@533333q@�����-�@    �q@03333'�@53333�q@����� �@������q@������@������q@������@������q@�������@63333�q@03333��@63333�q@�����Y�@    �q@�����<�@iffff�q@�����+�@    �q@������@�����Ar@cffff�@����̌r@�������@������r@������@�����It@03333�@jffffVu@dffff�@�����Lu@�����	�@jffffFu@�����{�@jffffu@�������@    0t@�������@����̜s@cffffN�@������r@�����%�@iffff&r@������@����̔q@�������@�����q@cffff��@iffffnp@������@iffff6p@������@iffffp@dffffր@�����p@�������@    �o@�����|�@������o@cffffB�@����̌o@������@�����Lo@�����a@    o@������~@������n@`ffff�}@hffff.p@�����~@������p@`ffffn~@hffffq@`ffff@    @q@�����T@hffffnq@`ffff�@53333�q@`ffff�@�����r@������@53333sr@������@hffffs@������@hffffvs@������@    �s@�����@����̄s@������~@hffffvs@�����W~@�����as@_ffff~@43333Cs@_ffff�}@gffff�r@�����}@43333�q@�����q|@43333�p@�����1|@    pp@�����|@    �o@�����|@    �n@������{@533333n@_ffff�{@53333�m@������{@    �m@������{@������m@�����A{@������m@������z@53333cm@������z@    0m@�����Dz@������l@�����'z@�����9l@^ffff6z@������k@�����Gz@�����,k@+3333{z@�����9k@������z@hffffFk@�����!{@53333Sk@^ffffv{@hffffvk@^ffff�{@    �k@�����|@    `k@�����D|@hffff�j@+3333k|@������i@+3333�|@����̌h@������|@    �g@+3333[}@� �X
@z���	��� 
`ͳ�@��� �<#������Y@�@Rd"pfffff�43333C�@`�� 43333�@S �������~@`H53333�}@�������4|@S��hffff�{@��� ����̴{@�͇ ������{@������6�    (|@�޾�����̄|@�*��53333�|@S��\�53333�|@�e��    }@@V�hffff6}@S ��53333�@ �B�43333C�@@���fr#S`���gffff��@`����v#�����lU�gffff��@�@$2��$c# �����Y#@��� �<#�@������.� �y���n.fffff�@@@��- �� #�-S���43333ˇ@`$��4N-���gffff��@S@�Y43333G�@ �43333߆@�����N@���*�`����d( �����'@�{�@�'S@��43333��@@b{�@pA'�����(�������P����)�����O��˶+�g��gffffއ@Ӡ=����-@.���j.@������.�p�] S@������$x@ ������x@`{������x@S@zA������w@������̄w@�����Y^@23333;w@S`J�����w@`W	������v@�i
23333�v@������e@�����wv@������e@effff^v@�In
23333Cv@S@dt
23333r@�~z
������k@ �}
�����ic@S�
�����Ya@ �x
.3333�^@`�o
.3333sZ@S��f
������V@�_
������V@ 3}	����̬V@S`m�������V@������Y@����̌V@23333�R@����̌V@233333P@����̌V@13333sK@bffff�V@13333sF@bffff�V@�����?D@/3333�V@dffff&C@bffff�W@������B@������X@dffff�B@����̌Y@������B@/3333sZ@������B@�����_[@efffffB@������h@�����?B@������q@�����B@effffNw@�����B@23333�w@233333B@������w@������B@������w@���:@m��Z ���p�] � 8� ��� ?��A�@�,@�� \z���Ӡ��`�Z�T1������t@ �������lt@S Թ�����dt@gffff�v@�����Ot@ 	������!t@S���������s@gffff�v@�����as@gffff�v@�����s@    �v@�����$p@@��������j@43333�v@effff�d@43333�v@������b@    �v@������b@43333�u@23333�b@gffffvs@23333sb@ oV23333sb@������m@23333sb@53333cm@23333sb@53333#m@������b@������l@������b@�����9l@�����yc@�����<l@�����od@�����<l@�����_e@�����<l@�����yl@    @l@������q@43333Cl@�YY���{�-�@��`�� 8� ��� �N@�@%��*d ��%gffffNq@�P&�����|&�`���-�& ��:�&�	��Έ&� ����N&�xD k&@��T�%�`�~���$@�!�[R#gffff�q@���"    hq@�����=�@gffff.q@�߿"��+ $�"�gffff�p@�h�"������p@ ��"gffff�p@�T�"Ӡऻ#`�(��~$ �N@�@%��o& � � t��w�@x�43333S@��vgffff&~@� �y U6 43333{@gffff�i@ ��S��fffff��@ z@�& �o& � 	5M      �� 5      $��2��6!   $��10,12.5q�61   $ 0,0,0,0��6D   $��1��6\   $��0q�6f   ���#5B51826z   �� 5�      $��3��6%    �� Orientation$ Vertical=�65   $��Center=�6L   .+�5�      �� -   5         ��Name$ txt_countAllPurchase��5�   (   $��Purchase��6H   $��14(�6X   $��Center=�6f   $��Regular"�5�   !   ���#70707066   �� 5�      $
��Bold"�6X   $��14(�6j   $��Center=�6x   ���#707070��6)   �� *countAllPurchase+ �� Mode$ OneWay=�6�   5�      5�      5�      �� 5�      $��10q�6   $��1��6%   
�������$ 7��5�      ._�5�      � 
������  5�      �� 5�      $	��7.5 �6/   �� 5�      $��* �6/   �� 5�      $
��auto �6/   �� 5�      $��2* �6/   .+�5�      �� ���#1D75B8$ 7,0,0,7��5�      F� 5�      ���#1D75B8$
 Fill=�6/   $��1��5�      $��LeftToRight=�6-   $��25��5�      $��25��6%   �����At��������8�����Lx@�8`M�Ӏ8���� .�At .Ӏj� .�J����J�`M�S�J������Lx@�j����At���`Ф��Ӏ���@�H�����Lx@@�H`M��@�H���� .`Ф .�@�. .������t@��������t@`M�������t@�����Lx@@�.��`Ф��� T�@>�Ѡ�	@>��@@�	@>���u	�K���j	�K������3l������b@43333�O@�+r�np�����`@43333�K@Q �� 43333�K@���v� ~V`�k�������%��@,B��������']	������^	����@�R���� W�gffff�d@������u@��Z������u@Q v������u@S �~������u@ �� W� ��@�R� ����^	� ����� �N@>� T�@>���T�`���UӀ4���dgffffFg@gffff�r@43333#g@�W��gffff�d@`:�
�    �d@��
43333�e@�0�	gffff�f@��	�gffff�f@ h�	�    �g@�%z	`��`�	@����I
� � �VӀj��`�`V���D��T��s�`.Z�����̌q@ �[Ӏ~<��dfffff�p@������̄p@����������o@�qw
�effff�o@���	23333Cp@�����	d@������p@������c@��X Ԅ	������dq@`�{	������q@���	 ��R
�����̄r@�i�@ܳ�6���P@�R�s�`.Z�@�;���Ӡ :@�@���H` �K@�^�@.;@�^S {������As@ 2P�����Q g{Q =p43333�e@S��q    �d@������u@    �c@�����iv@43333�c@Q �p43333�c@S@I�gffff�c@�����qw@������d@�Z    �e@�@�;���� �� b�
Q@�m43333sr@������{@    �r@�]�    Hs@�bgffff6s@ѠuS�Q������z@ �> 5v�������̼y@gffff&r@� ̿ $H
� ��`�	�-L 3}	`�����	Ѡ����	� �^ ҡ	�ܸ��
 �� b�
	5�      �� 5�      $��2��6!   $��10,12.5q�61   $ 0,0,0,0��6D   $��1��6\   $��0q�6f   ���#1D75B85�   !   �� 5�      $��3��6%   $ Vertical=�65   $��Center=�6L   .+�5�      �� -   5        $ txt_countAllSales��5�   (   $��Sales��6D   $��14(�6Q   $��Center=�6_   $��Regular"�5�   !   ���#70707066   �� 5�      $
��Bold"�6L   $��14(�6^   $��Center=�6l   ���#707070��6(   �� *countAllSalesValue+6�   5�      5�      5�      �� 5�      $��10q�6   $��2��6%   
�������$ 7��5�      ._�5�      � 
������  5�      �� 5�      $	��7.5 �6/   �� 5�      $��* �6/   �� 5�      $
��auto �6/   �� 5�      $��2* �6/   .+�5�      �� ���#FF5D6F$ 7,0,0,7��5�      F� 5�      ���#FF5D6F$
 Fill=�6/   $��1��5�      $��LeftToRight=�6-   $��25��5�      $��25��6%   �	�����ݑ�50�@�5�50gffffFY@������X@Q�9������W@Q�FH������W@S�FH������W@�a�������X@43333�^@�����lY@S�1j������Y@gfffff_@�p4�������yZ@�@Ë�%� W�����ݑ�50� Ƀ`���������[@@f�������[@�~������Z@��������LY@@ɢ������,Y@�B������Y@�B�������X@�B�������lX@�B��������V@�B�������U@��������U@@�M�������U@`PU������U@��\������U@��d�effffV@�E�������LV@ �>������W@��x�����,Y@��g��C�J] �w@i) Ƀ`���`I ظӀ� B�����43333SP@ ?�43333SP@�Cgffff&P@������[@43333P@�c������P@�+������P@ �.�@B  �.�@B ��Ѡ�c��Q��c�����L<@�ਤ@�p �ਤ�+�� �`� c ��`I ظ����@=Z���� @=Z���� �?�р���?�р��@=Z�����5O���� �5O���� �8�р���8�р���5O�`r�@=Z������L@@@=Z������L@@�?��`r��?��`r�@=Z�`r��5O������L@@�5O������L@@�8��`r��8��`r��5O��)�`iH� '9`iH� '9 l���)� l���)�`iH�fffffP@`iH�233333K@`iH�233333K@ l��fffffP@ l��fffffP@`iH� �{ �� �{ ��:� �@NrgfffffY@������9R@ ���G     Z@� C43333sZ@S �9gffff�[@��3    �\@ 82�(-р��(-��k� ���@� �� �{ �	5�      �� 5�      $��2��6!   $��10,12.5q�61   $ 0,0,0,0��6D   $��1��6\   $��0q�6f   ���#FF5D6F5�   !   �� 5�      $��3��6%   $ Vertical=�65   $��Center=�6L   .+�5�      �� -   5        $ txt_countAllVendor��5�   )   $��Vendor��6F   $��14(�6T   $��Center=�6b   $��Regular"�5�   !   ���#70707066   �� 5�      $
��Bold"�6S   $��14(�6e   $��Center=�6s   ���#707070��6)   �� *vendorCount+$ OneWay=�6�   5�      5�      5�      �� 5�      $��10q�6   $��3��6%   
�������$ 7��5�      ._�5�      � 
������  5�      �� 5�      $	��7.5 �6/   �� 5�      $��* �6/   �� 5�      $
��auto �6/   �� 5�      $��2* �6/   .+�5�      �� ���#FFB36B$ 7,0,0,7��5�      F� 5�      ���#FFB36B$
 Fill=�6/   $��1��5�      $��LeftToRight=�6-   $��25��5�      $��25��6%   ��������KQ���������7@� H��(k H�`�l`�� 6n�������?@��o ����o����oѠ����o�@x}��o�@x}@�Q@x}43333�:@S@x}gffff�:@ kz`�� �u`��рG7`���233333'@`����pr `��� �m `����j gffff�:@��j @����j ��o�`M/ ��o� � ��o�@ ��ogffff�7@�hQ    43333�5@�     �Igfffff5@�����L5@S    �����L5@�����L5@�����L5@S    4333335@��      5@�� hffff�4@S�� hffff�4@�� hffff�4@�� ������4@S�� 43333�4@@ ������4@@ ������4@S � hffff�3@�� hfffff3@�� �����3@� 	=  �Q 	= ������1@�`M/ @f�%&  $� �%& ��� Q�%& 433333,@р�  P� ��� ஻ �� �� `# @� Ӡ%& `_� ��* �ا ������@ R� �������	@�7� 233333@gfffff$@������@�� �ffffff@`�� ������@�n� ������@`�� � �� ��� �@T�  � �n�  �� �� �ˤ ������#@gfffff&@ � gfffff'@��� gfffff(@�`�� `3� Q`�� gfffff-@�`�� ��� �`��  $� �͇ @f z  �Q z gfffff2@� � `q#S �� 4333333@@�� �~& R� ��)�@]� ���@]� ��@]� ��@]� ���@]� ��S �� 4333330@ R� gfffff-@ R�      *@Q R� gfffff(@S R� gfffff(@�ˤ 433333(@�ˤ      (@р��  G� S�� 433333 @��� @�p  �� 433333@S�ˤ ������@@� 433333@��� ������@Q��������@Ӏ� >I ��@KL @(`�S �`�/�Z @:4�.c �����L4@`Vl ������4@������@2333335@�pr ������5@������@Ӏ�O�,� ��R�ڊ ��O@�� Q Egfffff(@S Egfffff(@�|C஻ ��A�5� ���A@]� ���A�M� ��5@1� ��!�����!�����!����!gffff�2@��!gffff�2@Q@o@    �3@S�|C�����L3@`H�����3@@�L     3@Q �igfffff2@S��fgfffff2@ b`<��^`<р�[`<���R���K ��K@fѠK��� ӠK� � ������7@�� ����� �gfffff<@�� `W�� � `W���� �`W� �� �`W� $� �`W�@f�`W� �gffff�=@�����`<�@��`<S`��gfffff2@�Y��I�Ŭ�I� J� �$�@��@(`�� �,gfffff?@�����4@    �?@�����4@�-�@:443333�?@�����L4@� H�`�;����|C����K	5�      �� 5�      $��2��6!   $��10,12.5q�61   $ 0,0,0,0��6D   $��1��6\   $��0q�6f   ���#FFB36B5�   !   �� 5�      $��3��6%   $ Vertical=�65   $��Center=�6L   .+�5�      �� -   5        $ txt_countAllCustomer��5�   (   $��Customer��6G   $��14(�6W   $��Center=�6e   $��Regular"�5�   !   ���#70707066   �� 5�      $
��Bold"�6V   $��14(�6h   $��Center=�5�   *   ���#707070��5�   *   �� *customerCount+$ OneWay=�5�   H   5�      5�      5�      �� 5�      $��10q�6   $��4��6%   
�������$ 7��5�      ._�5�      � 
������ 
 5�      �� 5�      $��10 �6,   �� 5�      $��* �6,   .+�5�      �� ���#49BBEB$ 7,7,0,0��5�      �� 5�      -   5         ��Name$ 	cb_branch��5�   #   $��1��67   $��10,0,5,0q�5�   %   ���#4E4E4E & "MaterialDesignFloatingHintComboBox#��[ 5�   %   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Branch Name ...��5�   %   $��40��5�   &   $��5q�64   ���#737373$��0q�5�   &    �� 
IsEditable . 6:   5�      5�      �� 5     $��10q�6   $��1��6%   $��0��62   $��2��6B   
�������$ 7��5     ._�5     � 
������ 
 5     �� 5     $��25 �6,   �� 5     $��* �6,   .+�5     �� ���#00CC9E$��7��66   $ 7,7,0,0��5	     �� 5
     -   5        $ bestSellerTitle��5
  $   $��Best Seller��6=   $
��Bold"�6P   $��16(�6b   $��Center=�5  $   $��Center=�6A   $��7��5     
�������60   � 5     -	   5        $ grid_bestSeller��5      $��1��69   
 5     �� 5  "   $
��auto �60   �� 5  "   $��* �60   �� 5  "   $
��auto �60   �� 5  "   $��* �60   �� 5  "   $
��auto �60   �� 5  "   $��* �60    5     �� 5  "   $
��auto �63   �� 5  "   $
��auto �63   �� 5  "   $
��1.5* �63   �� 5  "   $
��auto �63   �� 5  "   $��* �63   5     5     5     �� 5      $��10q�6   $��1��6%   $��2��62   $��2��6B   
�������$ 7��5!     ._�5"     � 
������ 
 5#     �� 5$     $��25 �6,   �� 5%     $��* �6,   .+�5'     �� ���#BC80EF$��6��66   $ 7,7,0,0��5(     �� 5)     -
   5        $ storageTitle��5)  %   $��Storage��6;   $
��Bold"�6J   $��16(�6\   $��Center=�6j   $��Center=�6�   $��6��5*     
�������60   �� 5+     -   5         ��Name$ btn_storageSetting��5-     $��25��5+  :   $��25��6E   $
��Left=�5,  #   $��Center=�6>   $��0q�6Y   $��0q�5.  3   ��5+  "   Z� ��5.     Z� .��5/     F� 
�������$
 Fill=�60   $��15��50     $��15��6&   $��LeftToRight=�51     ������pS���pS`��р����Ӡ\�`��4���r �`z`Ѡ� �Ѡ�� P� �@�q�	� ��L_��� @�L�@�  '9 &� Q@)������ @������<@������ @Q�h�433333,@S���������,@@Cq     .@��^433333/@�` P� �`��  ����� `z`� [� ��r �� `���� ���ffffff @`���ffffff @�р�� ��:S`3� �����YC@ [� `�`��� �"s�`�� @��`@M���^����@Cq�������\��h� w��������<@`�T�@)`�T� '9 w������LC@gffff�H@�L_���@�q���Ѡ��@MѠ�@�� ��"s��4�`�` ����N�����:��pS��p H�Ӡp�3�3�p H��p�`���p`z`�3`z` H��`z``��`��`z` H�`z`Ӡ3`z`�p`���p H�	68   56     � 57     -   5        $ grid_IUStorage��57      $��1��68   
 58     �� 59  "   $
��auto �60   �� 5:  "   $��* �60   �� 5;  "   $
��auto �60   �� 5<  "   $��* �60   �� 5=  "   $
��auto �60   �� 5>  "   $��* �60    5@     �� 5A  "   $
��auto �63   �� 5B  "   $
��auto �63   �� 5C  "   $
��1.5* �63   �� 5D  "   $
��auto �63   �� 5E  "   $��* �63   5G     5I     5J     �� 5K     $��10q�6   $��1��6%   $��5��62   
�������$ 7��5L     ._�5M     � 
������ 
 5N     �� 5O     $��25 �6,   �� 5P     $��* �6,   �� 5Q     $��* �6,    5S     �� 5T     $
��auto �6/   �� 5U     .+�5W     �� ���#FF5D6F$��2��66   $ 7,7,0,0��5X     �� 5Y     -   5        $ txt_userOnlineTitle��5Y  $   $��Users��6A   $
��Bold"�6N   $��16(�6`   $��Center=�5Z  %   $��Center=�6B   $��6��5[     
�������60   �� 5]     $��1��6%   $��0��62   $	��5,1q�6C   $ 
Horizontal=�6P   $��Center=�5^  %   $��Center=�6C   .+�5_     �� -   5        $ txt_userOnline��5_  5   $��1��6(   $��Online:��6N   $��16(�6]   $
��Bold"�5`  !   ���#707070$��0,0,5,0q�6H   �� 5a     $
��Bold"�6R   $��16(�6d   ���#008A1C��6)   �� *
userOnline+$ OneWay=�6r   5b       5d     -   5          Name$ pch_userOnline��5e  '   $��1��5d  '   $��1��64   $��Center=�6D   5e  '   � 5f     -   5        $ grid_userImages��5f     $��2��69   $��2��6F   $��Center=�6Z    5g     �� 5h  "   $
��auto �63   �� 5i  "   $
��auto �63   �� 5j  "   $
��auto �63   �� 5k  "   $
��auto �63   �� 5l  "   $
��auto �63   5n     5o     5p     �� 5s     $��10q�6   $��2��6%   $��5��62   
�������$ 7��5t     ._�5u     � 
������ 
 5v     �� 5w     $��25 �6,   �� 5x     $��* �6,    5z     �� 5{     $
��auto �6/   �� 5|     .+�5~     �� ���#BC80EF$��2��66   $ 7,7,0,0��5     �� 5�     -   5        $ txt_branchOnlineTitle��5�  $   $��Branch & Store��6D   $
��Bold"�6^   $��16(�6p   $��Center=�5�  %   $��Center=�6B   $��6��5�     
�������60   �� 5�     $��1��6%   $��0��62   $	��5,1q�6C   $ 
Horizontal=�6P   $��Center=�5�  %   $��Center=�6C   .+�5�     �� -   5        $ txt_branchOnline��5�  6   $��1��6(   $��Online:��6P   $��16(�6_   $
��Bold"�5�  !   ���#707070$��0,0,5,0q�6H   �� 5�     $
��Bold"�6S   $��16(�6e   ���#008A1C��6(   �� *branchOnline+$ OneWay=�6s   5�       5�     -   5        $ 
pch_branch��5�  '   $��1��5�  '   $��1��64   $��Center=�6D   5�  '   5�     5�     �� 5�     $��10q�6   $��3��6%   $��5��62   
�������$ 7��5�     ._�5�     � 
������ 
 5�     �� 5�     $��25 �6,   �� 5�     $��* �6,    5�     �� 5�     $
��auto �6/   �� 5�     .+�5�     �� ���#5B5182$��2��66   $ 7,7,0,0��5�     �� 5�     -   5        $ txt_dailyPurchaseTitle��5�  $   $��Daily Purchase��6D   $
��Bold"�6Z   $��16(�6l   $��Center=�5�  %   $��Center=�6B   $��6��5�     
�������60   �� 5�     $��1��6%   $��0��62   $	��5,1q�6C   $ 
Horizontal=�6P   $��Center=�5�  %   $��Center=�6C   .+�5�     �� -   5        $ txt_countDailyPurchase��5�  5   $��1��6(   $��0,0,5,0q�6U   $��Count:��6f   $��16(�6t   $
��Bold"�5�  !   ���#70707063   �� 5�     $
��Bold"�6\   $��16(�6n   ���#008A1C��6(   �� *countDailyPurchase+$ OneWay=�6|   5�       5�     -   5        $ pch_dailyPurchaseInvoice��5�  '   $��1��5�  '   $��1��64   $��Center=�6D   5�  '   5�     5�     �� 5�     $��10q�6   $��4��6%   $��5��62   
�������$ 7��5�     ._�5�     � 
������ 
 5�     �� 5�     $��25 �6,   �� 5�     $��* �6,    5�     �� 5�     $
��auto �6/   �� 5�     .+�5�     �� ���#1D75B8$��2��66   $ 7,7,0,0��5�     �� 5�     -   5        $ txt_dailySalesTitle��5�  $   $��Daily Sales��6B   $
��Bold"�6U   $��16(�6g   $��Center=�5�     $��Center=�68   $��6��5�     
�������60   �� 5�     $��1��6%   $��0��62   $	��5,1q�6C   $ 
Horizontal=�6P   $��Center=�5�  %   $��Center=�6C   .+�5�     �� -   5        $ txt_countDailySales��5�  5   $��1��6(   $��Count:��6S   $��16(�6a   $
��Bold"�5�  !   ���#707070$��0,0,5,0q�6H   �� 5�     $
��Bold"�6V   $��16(�6h   ���#008A1C��6(   �� *countDailySales+$ OneWay=�6v   5�       5�     -   5        $ pch_dailySalesInvoice��5�  '   $��1��5�  '   $��1��64   $��Center=�6D   5�  '   5�     5�     �� 5�     $��10q�6   $��2��6%   $��3��62   $��4��6D   
�������$ 7��5�     ._�5�     � 
������ 
 5�     �� 5�     $��25 �6,   �� 5�     $��* �6,   .+�5�     �� ���#49BBEB$ 7,7,0,0��5�     �� 5�     -   5        $ purchaseAndSalesTitle��5�  $   $��Purchase & Sales��6C   $
��Bold"�6_   $��16(�6q   $��Center=�6   $��Center=�6�   $��6��5�     
�������60   #	  LiveCharts.Wpf.CartesianChart	  5�     $��1��6-   $��5q�6;      LegendLocation$ Right=�5�     
�������   Series 5�     �� *SeriesCollection+   AxisY 5�  "   
  LiveCharts.Wpf.Axis
  -   5         
 Name$ 	axs_AxisY��5�  +    
  MinValue$ 0Q�6>    
  LabelFormatter 6M   �� *
YFormatter+6u      AxisX 5�  "   
  -   5        $ 	axs_AxisX��5�  +   $ 0Q�6>    
  MaxValue$ 30Q�6K    
  Labels 6[   �� *Labels+6w   5�     5�     5�     �� 5�     -   5        $ txt_rightReserved��5�     $��7��5�     $��0��6)   $��12(�6:   $��6��6H   $��Normal"�5�     ���#9B9B9B$��Center=�5�     $��25,5,5,5q�63   $-��'2021 © All Right Reserved for Increase��5�     5�     5�     5�     5�     