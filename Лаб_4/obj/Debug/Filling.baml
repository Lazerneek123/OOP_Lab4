   M S B A M L   `   `   `  ����C  ?Лаб_4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Лаб_4Лаб_4  5   	       Лаб_4.Filling   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Лаб_4     5   	     � Title$/  )Заповнення інформації��5   	   $	��650��6'   $	��850��64    � WindowStyle$
 None=�6@    � 
ResizeMode$ NoResize=�6S   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�   
���   � � Icon$t nC:\Users\lenovo\Desktop\Домашка 4 семестр\ООП\Лаб4\Лаб_4\Лаб_4\bin\Debug\favicon.ico��6�   .��5	      ��  �� CornerRadius$ 40��6   
�������._�5
   
   � .+�5      �� -   5        $��buttonClose��5      $
��Left=�6(   $	��Top=�6C   $��36��6[   $��37��6f   
���  ��$��Normal$�6�   $��20(�6�   $��	UltraBold"�6�   
���   �$��
787,10,0,0q�6�   6�   �� 5      -   5        $��buttonCollapse��5      $
��Left=�6+   $	��Top=�6F   $��36��6_   $��37��6j   
��� � �$��Normal$�6�   $��20(�6�   $��	UltraBold"�6�   
���   �$��
746,10,0,0q�6�    J� RenderTransformOrigin$ 1.507,0.581&�6  �� 5      -   5        $��	ButtonAdd��5      $��Додати��6&   $
��Left=�67   $��
60,524,0,0q�6R   $	��Top=�6f   $	��210��6~   $��95��6�   
��� � �$��	UltraBold"�6�   $��Normal$�6�   $��18(�6�   �� 5      -   5        $��channel��5      $+��%Вимірювальний канал��6#   $��319,39,316,569q�6A   $��Normal$�6Y   $��18(�6l   $��	UltraBold"�6z   $ 0.234,-1.31&�6�   �� 5      -   5        $��ButtonCancel��5      $��Відмінити��6)   $
��Left=�6=   $��572,524,0,0q�6X   $	��Top=�6m   $	��210��6�   $��95��6�   
���  ��$��	UltraBold"�6�   $��Normal$�6�   $��18(�6�   �� 5      -   5         ��Name$ information_Copy��5      $��Датчик��6.   $��366,326,410,287q�6@   $��Normal$�6Y   $��18(�6l   $��	UltraBold"�6z   $ 0.234,-1.31&�6�   �� 5      -   5        $ information_Copy1��5      $��Пристрій��6/   $��366,198,383,410q�6B   $��Normal$�6[   $��18(�6n   $��	UltraBold"�6|   $ 0.234,-1.31&�6�   �� 5      -   5        $ information_Copy2��5      $8��2Загальна кількість каналів��6/   $��110,110,539,503q�6T   $��Normal$�6m   $��14(�6�   $��	UltraBold"�6�   $ 0.234,-1.31&�6�   �� 5      -	   5        $ information_Copy3��5      $��Номер каналу��6/   $��572,105,165,508q�6F   $��Normal$�6_   $��14(�6r   $��	UltraBold"�6�   $ 0.234,-1.31&�6�   �� 5      -
   5        $ information_Copy4��5      $6��0Дата калібрування датчика��6/   $��172,266,471,353q�6S   $��Normal$�6l   $��14(�6   $��	UltraBold"�6�   $ 0.234,-1.31&�6�   �� 5      -   5        $ information_Copy5��5      $��Тип величини��6/   $��349,387,392,236q�6F   $��Normal$�6_   $��14(�6r   $��	UltraBold"�6�   $ 0.234,-1.31&�6�   �� 5      -   5        $ information_Copy6��5      $-��'Діапазон вимірювання��6/   $��60,387,614,225q�6N   $��Normal$�6f   $��14(�6y   $��	UltraBold"�6�   $ 0.234,-1.31&�6�   �� 5      -   5        $ information_Copy7��5      $G��AПоточне значення фізичної величини��6/   $��538,387,41,231q�6\   $��Normal$�6t   $��14(�6�   $��	UltraBold"�6�   $ 0.234,-1.31&�6�   (  "System.Windows.Controls.DatePicker  5      -   5        	  Name$
	 date��5      $
��Left=�6'   $	��Top=�6B   $ 0.683,1.788&�6Z   $��482,266,0,0q�6~   $��30��6�   $	��119��6�   $��14(�6�   
�������
���   �$��	UltraBold"�6�   �� 5      -   5        
 ��Name$
 textBox1��5      $
��Left=�6(   $��25��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6c   $	��120��6{   $��
78,430,0,0q�6�   $��14(�6�    �� 	MaxLength$ 3��6�   $��	UltraBold"�6�   
�������
���   � �� TextAlignment$ Center=�6  �� 5      -   5        $
 textBox2��5      $
��Left=�6(   $��25��6C   $
 Wrap=�6O   $	��Top=�6c   $	��120��6{   $��627,430,0,0q�6�   $��14(�6�   $ 3��6�   $��	UltraBold"�6�   
�������
���   �$ Center=�6  �� 5      -   5         ��Name$ 	comboBox1��5      $
��Left=�6*   $	��Top=�6E   $	��129��6]   $��338,430,0,0q�6i   
�������$��14(�6�   $��	UltraBold"�6�   
���   �6�   �� 5      -   5        $ information_Copy8��5      $��0��6/   $��196,147,605,466q�6;   $��Normal$�6T   $��18(�6g   $��Black"�6u   $ 0.234,-1.31&�6�   �� 5      -   5        $ information_Copy9��5      $��0��6/   $��607,147,204,466q�6;   $��Normal$�6T   $��18(�6g   $��Black"�6u   $ 0.234,-1.31&�6�   5      5      5       