   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Form3   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Form3��5   	   $	��450��6   $	��800��6$   .��5	      � .+�5
   
   �� -   5         ��Name$
 list��5
      $
��Left=�6A   $	��216��6\   $��	81,63,0,0q�6i   $	��Top=�6|   $	��627��6�   ��6!   �� *	Product+ �� View 5      �� 5      .P�5      �� $��id��6P    �� Width$
 auto��6\    �� DisplayMemberBinding 6%   ��  �� Path$
 id_P�6\   �� 5      $
��name��6M   $
 auto��6[    6%   �� *name_P+6[   �� 5      $��price��6N   $
 auto��6]    6%   �� *	price_P+6]   �� 5      $
��desc��6M   $
 auto��6[    6%   �� *desc_P+6[   5      5      �� 5   
   -   5         ��Name$	 add��5      $��Добавить��6   $
��Left=�61   $��170,317,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $ basket��5      $��Корзина��6!   $
��Left=�63   $��525,317,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6]   $��23��6x   $��328,303,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6#   �� 	 �� ElementName$
	 list��$ SelectedItem.id_P�6�   5      5      