   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   J FHomeAccountancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HomeAccountancy.WindowsHomeAccountancy.Windows 5   	   (   "HomeAccountancy.Windows.RentWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   7local%clr-namespace:HomeAccountancy.Windows     5   	   $��1q�5	   	     � WindowStartupLocation$  CenterScreen=�5
   	   (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 ����� � Icon$ ../Content/icon.ico��5   	      	TitleCaps .  $	��550��5   	   $	��450��6   $��0q�6"   $��0q�6-    � 
ResizeMode$ NoResize=�5   	    � Title$ Валюти��5   	   ���#FAFAFA.��5      ��  �� Padding$ 10q�6   ._�5   
   � -   5        $��DataPresenter��5       � ColumnDefinitions 5      �� 5      �� 5       � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5       �� $��0��6   $��0��6%   $��Валюта 1:��65   $��14(�6F   �� 5!      $��0��6   $��1��6%   $��Валюта 2:��65   $��14(�6F   �� 5#      $��0��6   $��1��6&   $��0 5 15 5q�63   $��14(�5%      
�������$	��0.5q�6<   ��5$      �� *
Currencies+	 �� SelectedItem	 69   �� *SelectedCurrency1+��5&      �� 5'      .R�5(      �� 
 �� Orientation$
 
Horizontal=�6%   $��5q�6>   .+�5)      �� ��6(   �� *
FullName+�� 5*      $��5 0 0 0q�6(   ��69   �� *ShortageName+ �� StringFormat$ ({0})��5+      5,      5.      �� 5/      $��1��6   $��1��6&   $��15 5 0 5q�63   $��14(�51      
�������$	��0.5q�6<   ��50      �� *
Currencies+	 69   �� *SelectedCurrency2+��52      �� 53      .R�54      �� $
 
Horizontal=�6%   $��5q�6>   .+�55      �� ��6(   �� *
FullName+�� 56      $��5 0 0 0q�6(   ��69   �� *ShortageName+$ ({0})��57      58      5:      � 5<      $��2��6   $��0��6    $��0 5 15 0q�60    5=      �� 5>      �� 5?      .+�5A      �� $��0��6   $��0 5 5 5q�6*   ��6;   �� *SelectedCurrency1.FullName+�� 5B      $��1��6   $��5 5 0 5q�6*   ��6;   �� * SelectedCurrency1.ShortageName+5C      � 5E      $��2��6   $��1��6    $��15 5 0 0q�60    5F      �� 5G      �� 5H      .+�5J      �� $��0��6   $��0 5 5 5q�6*   ��6;   �� *SelectedCurrency2.FullName+�� 5K      $��1��6   $��5 5 0 5q�6*   ��6;   �� * SelectedCurrency2.ShortageName+5L      �� 5N      $��3��6   $��0��6&   $��2��66   $
 
Horizontal=�6J   .+�5O      �� $ ��Курс переводу:��6   $��Center=�62   $��0 0 5 0q�6M   *   $MahApps.Metro.Controls.NumericUpDown  5P         HasDecimals .    Speedup . $��80��6L      Minimum$
 0.01Q�5Q   %      Maximum$	 100Q�64      Interval$
 0.01Q�6D      StringFormat$ N2��6T      Value 6f   �� *	RateValue+5R      � 5T      $��4��6   $��0��6    $��0 5 15 0q�60    5U      �� 5V      �� 5W      .+�5Y      �� $��0��6      SquareButtonStyle#���   6)   $
��10 7q�5[      $��0 0 5 0q�6(   ��5Z      �� *DeleteCommand+��6;   �� *SelectedCurrency1+.��5[   9   Видалити6C   �� 5\      $��1��6   #���   6)   $
��10 7q�5]      $��5 0 0 0q�6(   ��5\   U   �� *AddNewCommand+.��5]   9   Створити6C   5^      5`      5a      5c      