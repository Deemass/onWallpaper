   M S B A M L   `   `   `  ����E  ADMSkin.WPF, Version=2.5.1.1, Culture=neutral, PublicKeyToken=null;,clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF
DMSkin.WPF  5   	   M5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPFDMSkin.WPF.Controls  5   	   F BonWallpaper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:onWallpaperonWallpaper 5   	      onWallpaper.MainWindow   5      7DMSkin,clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF  5   	   BControls5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPF  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:onWallpaper     5   	     � Title$  
MainWindow��5
   	   $	��700��6   $	��650��6(   $	��500��65   $	��550��6E    � 
ResizeMode$ CanResizeWithGrip=�6T    � AllowsTransparency .  J� OpacityMask
 �����#   DMSkin.WPF.DMSkinSimpleWindow   DMWindowShadowOpacity$ 1Q�5         DMWindowShadowSize$ 5Q�66   
������ .��5      � 
������ .+�5   
   �� -   5        $��myBorder��5       �� CornerRadius$ 8��6"   
�������63   � 5   
   
������� J� Opacity$	 0.8Q�6#    5      !� 5       !� Visual 6   �� 	 �� ElementName$	 myBorder��
 � RowDefinitions
 5      �� 5      $��45 �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��72 �6#   �� 5      $��* �6#   .+�5      � $��0��6   $��0��6    ���#1f22356G   � 5      $��0��6   $��1��6%    � Orientation$ 
Horizontal=�65   $	��Top=�6N   $��Right=�6f   .+�5      +   %DMSkin.WPF.Controls.DMSystemMinButton  (   "DMSkin.WPF.Controls.DMSystemButton   DMSystemButtonSize$ 30Q�6-   $   DMSystemButtonHoverForeground$ #FFFFFF��6E      DMSystemButtonForeground$ #383838��6m   $��Right=�6�   +   %DMSkin.WPF.Controls.DMSystemMaxButton  5      $ 30Q�6-   $ #FFFFFF��6E   $ #383838��6m   -   'DMSkin.WPF.Controls.DMSystemCloseButton  5       -   5        $ 30Q�5    G   $ #FFFFFF��6_   $ #383838��6�   5!      � 5"      $��1��6   $��2��6    ���#1f2235.+�5#      �� 
������� �� TabStripPlacement$
 Left=�60   $��0q�6I   .@�5$      #   DMSkin.WPF.Controls.DMTabItem  $��50��6)   $��70��65   $	����6@      simpleTabItem#��[  6R   $
��30px(�6y   .��5%      ��  �� Orientation$ Vertical=�6%   $��
45,0,100,0q�6<   .+�5&      �� $!��下载壁纸目录选择：��6(   ���#333333$��13(�6N   $��0,24,0,0q�6\   �� 5'      $ 
Horizontal=�6)   $��0,5,0,0q�6B   .+�5(   "   #   DMSkin.WPF.Controls.DMTextBox  -   5          Name$ downloadPathText��5(   5   $	��500��6O   $
��Left=�6^   $��13(�6y   $	��180��6�   $��30��6�      CornerRadius$ 4��6�    �� 
IsReadOnly .  � Cursor$ Arrow��6�   "   DMSkin.WPF.Controls.DMButton  5)   "   -   5        $��30��5)   5   $��选择目录��6B   $��12(�6Q      CornerRadius$ 4��6_   $	��8,1q�6p   $��12,0,0,0q�6~   6�   5*      �� 5+      $!��收藏壁纸目录选择：��6(   ���	#FF333333$��13(�6P   $��0,24,0,0q�6^   �� 5,      $ 
Horizontal=�6)   $��0,5,0,0q�6B   .+�5-   "     -   5        $ collectionPathText��5-   5   $	��500��6Q   $
��Left=�6`   $��13(�6{   $	��180��6�   $��30��6�   $ 4��6�    . $ Arrow��6�     5.   "   -   5        $��30��5.   5   $��选择目录��6B   $��12(�6Q   $ 4��6_   $	��8,1q�6p   $��12,0,0,0q�6~   6�   5/      �� 50      $!��选择壁纸切换时间：��6(   ���	#FF333333$��13(�6P   $��0,24,0,0q�6^   �� 51      $ 
Horizontal=�6)   $��0,5,0,0q�6B   .+�52   "     -   5        $	��500��52   5   $
��Left=�6D   $��13(�6_   $	��180��6m   $��30��6|   $ 4��6�   6�   �� 53   "   $	��秒��6,   ���	#FF333333$��13(�6L   $��12,0,0,0q�6Z   $��Center=�6l   54      �� 55      $��选择切换方式：��6(   ���	#FF333333$��13(�6N   $��0,24,0,0q�6\   �� 56      $ 
Horizontal=�6)   $��0,5,0,0q�6B   .+�57   "   '	   !DMSkin.WPF.Controls.DMRadioButton	  $��随机切换��69    	  	IconColor$ 	#FF1E9FFF��6H   $��12(�6^   	  58   "   $��按顺序切换��69   $ 	#FF1E9FFF��6I   $��12(�6_   $��24,0,0,0q�6m   59      �� 5:      $'��!选择收藏壁纸出现概率：��6(   ���	#FF333333$��13(�6R   $��0,24,0,0q�6`   �� 5;      $ 
Horizontal=�6)   $��0,5,0,0q�6B   .+�5<   "   �� -   5         ��Name$
 rate��5<   )   $��0,5,0,0q�67    � LargeChange$	 0.1Q�6H    � Maximum$ 1Q�6Z    � SmallChange$	 0.1Q�6f     DMOpacitySlider#��[ 6x   $	��260��6�    � ToolTip$ 32��6�   5=      �� 5>      $ 
Horizontal=�6)   $��0,24,0,0q�6B   .+�5?   "     -	   5        $��30��5?   L   $��启动��6Y   $��12(�6f   $ 8��6t   $	��8,1q�6�   $��0,0,0,0q�6�   5@      5A      5C        5D      $��50��6)   $��70��65   $	����6@   #��[  6R   $
��30px(�6y   5E      5F      �� 5G      $��Bottom=�6   $��Right=�6?   $��Right=�5H      $��Bottom=�6$   6A   5I      5J      5K      5L      