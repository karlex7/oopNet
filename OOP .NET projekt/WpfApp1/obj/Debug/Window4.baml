   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   C&clr-namespace:WpfApp1.Properties.LangsWpfApp1.Properties.Langs  5   	       WpfApp1.Window4   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   ;language&clr-namespace:WpfApp1.Properties.Langs     5   	     � Title$  Window4��5	   	   $	��450��6   $	��800��6&   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��
animateRec��5      $	��250��6&   $	��100��62    K� ZIndex$ 1��6?   
���  ��$��2��6[   $��271,22.2,272.6,17.8q�6o   $��2��6�   $��2��6�    � Triggers 5      :� 5       :� RoutedEvent$ Rectangle.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� 
TargetName$ 
animateRec��6.    �� TargetProperty$ Opacity�5   .    W� From$	 1.0X�5   .   		 W� To$		 0.0X�69   
 g� Duration$
 0:0:0.3D�6B    g� AutoReverse .  g� RepeatBehavior$ 0:0:0.9��5   A   W� 5       $ 
animateRec��6.   $ Width�5!   .   $	 250X�5"   .   $	 0X�69   $
 0:0:0.3D�6@    . $ 0:0:0.9��5#   A   5$      5%      5&      5(      �� 5*   
   #   WpfApp1.Properties.Langs.Lang
   ime#��Z 6   $��0��67   $��0��6D   $��Right=�6T   $��Center=�6p   �� 5+   
   -   5        $��lblIme��5+      $
��text��6   $��0��6-   $��1��6:   $
��Left=�6J   $��20 0 0 0q�6e   $��Center=�6w   �� 5-   
      broj#��Z 6   $��1��68   $��0��6E   $��Right=�6U   $��Center=�6q   �� 5.   
   -   5        $��lblBroj��5.      $
��text��6   $��1��6.   $��1��6;   $
��Left=�6K   $��20 0 0 0q�6f   $��Center=�6x   �� 50   
      pozicija#��Z 6   $��2��6<   $��0��6I   $��Right=�6Y   $��Center=�6u   �� 51   
   -   5        $��lblPozicija��51      $
��text��6#   $��2��62   $��1��6?   $
��Left=�6O   $��20 0 0 0q�6j   $��Center=�6|   �� 53   
      kapetan#��Z 6   $��3��6;   $��0��6H   $��Right=�6X   $��Center=�6t   �� 54   
   -   5        $��
lblKapetan��54      $
��text��6"   $��3��61   $��1��6>   $
��Left=�6N   $��20 0 0 0q�6i   $��Center=�6{   �� 56   
      
brojGolova#��Z 6   $��4��6>   $��0��6K   $��Right=�6[   $��Center=�6w   �� 57   
   -   5        $��lblBrojGolova��57      $
��text��6%   $��4��64   $��1��6A   $
��Left=�6Q   $��20 0 0 0q�6l   $��Center=�6~   �� 59   
      	brojZutih#��Z 6   $��5��6=   $��0��6J   $��Right=�6Z   $��Center=�6v   �� 5:   
   -   5        $��lblBrojZutih��5:      $
��text��6$   $��5��63   $��1��6@   $
��Left=�6P   $��20 0 0 0q�6k   $��Center=�6}   5<      5=      