   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   J FHomeAccountancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HomeAccountancy.WindowsHomeAccountancy.Windows 5   	   *   $HomeAccountancy.Windows.FilterWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   7local%clr-namespace:HomeAccountancy.Windows     5   	   $��1q�5	   	     � WindowStartupLocation$  CenterScreen=�5
   	   (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 ����� � Icon$ ../Content/icon.ico��5   	      	TitleCaps .  $	��500��5   	   $	��350��6   $��0q�6"   $��0q�6-    � 
ResizeMode$ NoResize=�5   	    � Title$ Фільтр��5   	   ���#FAFAFA.��5      � -   5        $��DataPresenter��5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��2��6    �� TabStripPlacement$
 Left=�6)   -   'MahApps.Metro.Controls.TabControlHelper	   
Underlined$	 TabPanel=�6B   
 � DataContext
 6r   �� *CurrentFilter+.@�5      �� $��Дата запису��6   +   %MahApps.Metro.Controls.ControlsHelper   HeaderFontSize$ 16Q�6+   .��5      ��  �� Padding$ 10q�6   ._�5      �  5      �� 5       $
��auto �6,   �� 5!      $
��auto �6,   �� 5"      $
��auto �6,    5$      �� 5%      $
��auto �6/   �� 5&      .+�5(      �� -   5        $��DateFilterEnabled��5(   D   $��0��6#   $��2��60    d� 	IsChecked 5)   #   �� *IsDatesFilter+.��6G   53Фільтрувати за датою запису6d   �� 5*      $��Дата від��6$   $��1��64   $��0��6A   $��Center=�6Q   (  "System.Windows.Controls.DatePicker  5+      $��1��6%   $��1��62      DisplayDateEnd$ 
2030-01-01X�5,         DisplayDateStart$ 
2010-01-01X�69      IsTodayHighlighted . *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Від��5-      $��10 5 0 0q�6E   {�5.   %   ��  �� ElementName$ DateFilterEnabled�� �� Path$ 	IsChecked�   SelectedDate 5/   %   �� *
FromDate+�� 50      $��Дата до��6$   $��2��63   $��0��6@   $��Center=�6P     51      $��2��6%   $��1��62   $ 
2030-01-01X�52      $ 
2010-01-01X�69    . $
 До��53      $��10 5 0 0q�6C   {�54   %   �� $ DateFilterEnabled��$ 	IsChecked� 55   %   �� *ToDate+56      57      58      �� 59      $��Сума платежу��6   $ 16Q�6,   .��5:      �� $ 10q�6   ._�5;      �  5<      �� 5=      $
��auto �6,   �� 5>      $
��auto �6,   �� 5?      $
��auto �6,    5A      �� 5B      $
��auto �6/   �� 5C      .+�5E      �� -   5        $��SumFilterEnabled��5E   D   $��0��6#   $��2��60    5F   #   �� *IsSumFilter+.��6E   75Фільтрувати за сумою платежу6c   �� 5G      $#��Мінімальна сума��6$   $��1��6;   $��0��6H   $��Center=�6X   *   $MahApps.Metro.Controls.NumericUpDown  5H      $��1��61   $��1��6>      HasDecimals .    Speedup .    Minimum$ 0Q�5I   )      Maximum$ 1000000Q�65      Interval$ 10Q�6I      StringFormat$ N2��6W   $��10 5 0 0q�6i   {�5J   1   �� $ SumFilterEnabled��$ 	IsChecked�   Value 5K   1   �� *MinSum+�� 5L      $%��Максимальна сума��6$   $��2��6<   $��0��6I   $��Center=�6Y     5M      $��2��61   $��1��6>    .  . $ 0Q�5N   )   $ 1000000Q�65   $ 10Q�6I   $ N2��6W   $��10 5 0 0q�6i   {�5O   1   �� $ SumFilterEnabled��$ 	IsChecked� 5P   1   �� *MaxSum+5Q      5R      5S      �� 5T      $'��!Категорії платежу��6   $ 16Q�61   .��5U      �� $ 10q�6   ._�5V      �  5W      �� 5X      $
��auto �6,   �� 5Y      $��* �6,   .+�5[      �� -   5        $��CategoryFilterEnabled��5[   0   $��0��6#    5\   #   �� *IsCategoryFilter+.��6J   A?Фільтрувати за категорією платежу6m   �� 5]      -   5        $��CategoriesList��5]   0   $��1��6#   $��10 5 0 0q�5^   #   $
��Auto=�65   {�5]   F   �� $ CategoryFilterEnabled��$ 	IsChecked���5_      �� 5`   "   .R�5a   &   ��  �� Orientation$ 
Horizontal=�61   .+�5b   *   �� ��63   ��  6G   �� $ 
IsSelected� �� RelativeSource �� *FindAncestor+ �� AncestorType" ��5d   '   5e   #   5g      5h      5i      5j      �� 5k      $#��Рахунок платежу��6   $ 16Q�6/   .��5l      �� $ 10q�6   ._�5m      �  5n      �� 5o      $
��auto �6,   �� 5p      $��* �6,   .+�5r      �� -   5        $��AccountFilterEnabled��5r   0   $��0��6#    5s   #   �� *IsAccountFilter+.��6I   =;Фільтрувати за рахунком платежу6j   �� 5t      -   5        $��AccountsList��5t   0   $��1��6#   $��10 5 0 0q�5u   #   $
��Auto=�65   {�5t   D   �� $ AccountFilterEnabled��$ 	IsChecked���5v      �� 5w   "   .R�5x   &   �� $ 
Horizontal=�61   .+�5y   *   �� ��63   ��  6G   �� $ 
IsSelected� �� *FindAncestor+" ��5{   '   5|   #   5~      5      5�      5�      5�      �� 5�   
   -   5        $��2��5�      $��1��6   $��10q�6.      AccentedSquareButtonStyle#��[  6:   $
��10 4q�5�   -   $	��150��6<   $��Right=�6H   .��6d   !Примінити фільтр6v   �� 5�   
   -	   5        $��2��5�      $��0��6     SquareButtonStyle#���  6.   $��10q�6Z   $
��10 4q�6f   $	��150��6u   $
��Left=�5�      .��6H   Очистити фільтр6Y   5�      5�      