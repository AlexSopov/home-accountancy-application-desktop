   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5      J FHomeAccountancy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HomeAccountancy.ConvertersHomeAccountancy.Converters 5      1clr-namespace:HomeAccountancyHomeAccountancy 5	          HomeAccountancy.SurveyView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      Bcol2clr-namespace:System.Collections;assembly=mscorlib     5      >	converter(clr-namespace:HomeAccountancy.Converters     5      /localclr-namespace:HomeAccountancy     5	        � 	Resources  5      :  4HomeAccountancy.Converters.DateTimeToStringConverter   DateToStrongConverter��%   &	          5   
   6.   5      .��5      � -   5        $��MainContent��5   <     MainBackgroudColor#��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��0.8* �6   �� 5      $
��0.2* �6   .+�5   
   ]� $��0��6   $��0��6!   $��0 0 0 10q�61   .+�5      �� $��Рахунок:��6   $
��Left=�6(   $��Center=�6>   �� 5      -   5        $��Accounts��5   T   $	��200��6   $
��Left=�6#   $
��Left=�69   $��10 0 0 0q�6d    �� SelectedItem 5      �� *SelectedAccount+5!      �� 5$   
   $��1��6   $��0��6   $��1q�6.   
�������._�5%      &   System.Windows.Controls.DataGrid  -   5        $��DataContainer��5%      $��12(�6,      AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�5&   i      
IsReadOnly .  %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$ 1 5'   )    %� CacheLengthUnit$
 Page=�6K   ��5&      �� *Transactions+ 6<   �� *SelectedTransaction+��5(      �� 5)      	 �� 
TargetType"	  6   
 �� BasedOn#
 [B 62   .�5*      ��  �� Property  �@ AlternatingRowBackground �� Value �#FAFAFA6E   5+         Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��5/   )      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5.   )   ��  �� Path$
 Date� �� 	Converter# [  5/   7     50      $ Рахунок��6Z   $	 200 6k    6)   �� $ TransactionAccount.Name�6k     51      $ Категорія��6V   $	 150 6i    6)   �� $ TransactionCategory�6i     52      $ Сума��6F   $
 auto 6T    6)   �� $	 Sum�6T     53      $ Валюта��6V   $	 100 6f    6)   �� $ TransactionCurrency�6f     54      $ Коментар��6N   $ * 6`    6)   �� $ Description�6`   56      57      �� 5:   
   $��1��6   $��1��6"    �� Orientation$ Vertical=�62   .+�5;      �� $��5 0 0 20q�6    �� Padding$ 	5 10 5 10q�6O   $��1q�6c   
���������6'   �� *CurrentRentColor+._�5<      �� $ Vertical=�6   .+�5=      �� 
�������$��18(�63   !Поточний залишок6S   � 5>       5?      �� 5@      $
��auto �6/   �� 5A      $
��auto �6/   .+�5C      �� -   5        $��CurrentRest��5C   4   $��0��6$   
�������$��20(�6[   $
��Bold"�6i   ��5D       �� *CurrentRent+ �� StringFormat$  {0:# ###.##; -# ###.##; 0}���� 5E      $��1��6$   
�������$��20(�6G   $
��Bold"�6U   $��5 0 0 0q�6g   ��5F       �� *SelectedAccount.Currency+5G      5H      5I      �� 5K      $��5 0 0 0q�6   $��1q�6&   
�������._�5L      �� $ Vertical=�6   .+�5M      �� $ 5 10 0 5q�6   ��60   �� *ExpectedRentColor+._�5N      �� $ Vertical=�6%   .+�5O      �  5P   "   �� 5Q   &   $��* �67   �� 5R   &   $
��auto �67   .+�5T   "   �� $��0��6,   
�������$��18(�6O   $��0 0 5 0q�6]   Прогноз залишку6   �� 5U   "   -   5        $��1��5U   )   $��0q�6O   
������ $��0 0 5 0q�6t   #��[" �5V   %   |�.  .��5W   &   �� $��../Content/refresh.png��6,   $��20��6L   $��20��6W   5X   #   5Y      �� 5Z      
�������$��12(�6;   $	��Top=�6I    на кінець місяця6s   � 5[       5\   "   �� 5]   &   $
��auto �67   �� 5^   &   $
��auto �67   .+�5`   "   �� $��0��6,   
�������$��20(�6O   $
��Bold"�6]   ��5a   %   �� *ExpectedRent+$  {0:# ###.##; -# ###.##; 0}���� 5b   "   $��1��6,   
�������$��20(�6O   $
��Bold"�6]   $��5 0 0 0q�6o   ��5c   %   �� *SelectedAccount.Currency+5d      5e      5f      �� 5g      $ 
10 5 10 10q�6   
�������._�5h      �  5i      �� 5j   "   �� 5k   "    5m      �� 5n   "   $��* �63   �� 5o   "   $
��auto �63   �� 5p   "   $
��auto �63   �� 5q   "   $
��auto �63   .+�5s      �� $��0��6(   $��0��65   $��12(�6E    �� Padding$	 0 2q�6S   %#Очікуються витрати6u   �� 5t      -   5        $��ExpectedOutgo��5t   m   $��0��6(   $��1��65    �� TextAlignment$ Right=�6E   $
��Bold"�6[   $��12(�5u   (   $	 0 2q�66   ��6D   �� *
ExOuntgoes+$ {0:# ###.##;-# ###.##; 0}���� 5v      $��0��6(   $��2��65   $
��Bold"�6E   $��12(�6W   $��5 0 0 0q�6e   $	 0 2q�6v   ��5w   %   �� *SelectedAccount.Currency+�� 5x      $��1��6(   $��0��65   $��12(�6E   $	 0 2q�6S   #!Очікуються доходи6t   �� 5y      -   5        $��ExpectedIncome��5y   m   $��1��6(   $��1��65   $ Right=�6E   $
��Bold"�6[   $��12(�5z   (   $	 0 2q�66   ��6D   �� *	ExIncomes+$ {0:# ###.##;-# ###.##;0}���� 5{      $��1��6(   $��2��65   $
��Bold"�6E   $��12(�6W   $��5 0 0 0q�6e   $	 0 2q�6v   ��5|   %   �� *SelectedAccount.Currency+5}      5~      5�      5�      5�      � 5�   
   $��2��6   $��0��6   $��0 10 0 0q�6,    5�      �� 5�      $��* �6#   �� 5�      $
��auto �6#   �� 5�      $
��auto �6#   �� 5�      $
��auto �6#   .+�5�      �� $��1��6     SquareButtonStyle#���  6%   $	��8 0q�6Q   $
��20 8q�6^   ��5�      �� *DeleteCommand+��67   �� *SelectedTransaction+.��6i   Видалити6s   �� 5�      $��2��6   #���  6%   $	��8 0q�6Q   $
��20 8q�6^   ��5�      �� *ChangeCommand+��67   �� *SelectedTransaction+.��6h   Редагувати6t   �� 5�      -   5        $��3��5�      $��8 0 0 0q�6%     AccentedSquareButtonStyle#��[ 66   $
��20 8q�6{   .��6�   Додати запис6�   5�      5�      5�      