   M S B A M L   `   `   `  ����  SecondProject-    'SecondProject.UserControls.ListViewView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	��560��5   Y   $	��400��6f     � DataContext  6   ��    Locator �� Source# [   �� Path$ ListView�.��5      � .+�5   
   �� -   5        $��lvUsers��5   8   
������� �� DisplayMemberPath$
 Name��6�    �� SelectedItem 6   �� *
SelectItem+��6_   �� *CollectionView+5      �� 5	   
   $��	10,0,0,10q�6   $��Bottom=�6(   $
��Left=�6C   $	��238��6^   .+�5
      �� $�� ISBN:��6   �� 5      $�� Price:��6   �� 5      $�� Copies:��6   �� 5      $��
 Discount:��6   �� 5      $��
 In Stock:��6   5      �� 5   
   $	��Top=�6   $��Center=�6-   $��	0,312,0,0q�6J   $��84��6]   .+�5      �� -   5        $��Center=�5   g   $��60��6�   ��6   �� *
ItemISBM+ �� Mode$ TwoWay=�6�   �� 5      -   5        $��Center=�5   h   $��60��6�   ��6   �� *	ItemPrice+$ TwoWay=�6�   �� 5      -   5        $��Center=�5   h   $��60��6�   ��6   �� *	ItemCopie+$ TwoWay=�6�   �� 5      -   5        $��Center=�5   k   $��60��6�   ��6   �� *ItemDiscount+$ TwoWay=�6�   �� 5      -   5        $��Center=�5   h   $��60��6�   ��6   �� *	ItemStock+$ TwoWay=�6�   �� 5      $��35��6   $��80��6!   $
��Edit��6,   ��6;   �� *	EditBtn+�� 5      5      �� 5   
   $��Right=�6   $��Center=�61   $��	0,220,0,0q�6M   .+�5      �� $
��ISBM��67   $��5q�6F    d� 	IsChecked 6   �� *	CheckIsbm+6F   �� 5      $��Price��68   $��5q�6H    6   �� *
CheckPrice+6H   �� 5      $��Copies��69   $��5q�6J    6   �� *CheckCopies+6J   �� 5       $��Discount��6;   $��5q�6N    6   �� *CheckDiscount+6N   �� 5!      $��Stock��68   $��5q�6H    6   �� *
CheckStock+6H   5"      5$      5%      