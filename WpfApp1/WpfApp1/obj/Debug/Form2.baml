   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Form2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Form2��5   	   $	��450��6   $	��800��6$   .��5	      � .+�5
   
   �� -   5         ��Name$ ProductView��5
      $
��Left=�6(   $	��272��6C   $��	91,18,0,0q�6P   $	��Top=�6c   $	��613��6{    �� View 5      �� 5      .P�5      �� $��id��6P    �� Width$
 auto��6\    �� DisplayMemberBinding 6%   ��  �� Path$
 id_P�6\   �� 5      $
��name��6M   $
 auto��6[    6%   �� *name_P+6[   �� 5      $��price��6N   $
 auto��6]    6%   �� *	price_P+6]   �� 5      $
��desc��6M   $
 auto��6[    6%   �� *desc_P+6[   5      5      �� 5   
   -   5         ��Name$	 add��5      $��Добавить��6   $
��Left=�61   $��
91,370,0,0q�6L   $	��Top=�6`   $��75��6x    J� RenderTransformOrigin$ 3.43,-0.402&�6�   6�   �� 5   
   -   5        $ delete��5      $��Удалить��6!   $
��Left=�63   $��197,370,0,0q�6N   $	��Top=�6c   $��75��6{   $ 3.43,-0.402&�6�   6�   �� 5   
   -   5         ��Name$ NameBox��5      $
��Left=�6#   $��23��6>   	 �� TextWrapping$
	 Wrap=�6J   $�� ��6^   $	��Top=�6f   $	��120��6~   $��
92,322,0,0q�6�   �� 5   
   -   5        $ PriceBox��5      $
��Left=�6$   $��23��6?   $
	 Wrap=�6K   $�� ��6_   $	��Top=�6g   $	��120��6   $��217,322,0,0q�6�   $ 0.498,-0.357&�6�   �� 5   
   -   5        $ DescBox��5      $
��Left=�6#   $��23��6>   $
	 Wrap=�6J   $�� ��6^   $	��Top=�6f   $	��120��6~   $��342,322,0,0q�6�   $ 0.498,-0.357&�6�   5      5      