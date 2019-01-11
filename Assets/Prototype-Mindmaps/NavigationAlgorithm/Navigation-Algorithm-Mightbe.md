# Navigation Algorithm

Get the relationship between Bezier curve and the velocity of spaceship:
$$
B(t)=t^3\vec{P_4}+3t^2(1-t)\vec{P_3}+3t(1-t)^2\vec{P_2}+(1-t)^3\vec{P_1} \\
V_X = \frac{\mathrm{d}X_{B(t)}}{\mathrm{d}t} = \dots \\
V_Y = \frac{\mathrm{d}Y_{B(t)}}{dt} = \dots \\
V=\sqrt{V_X^2+V_Y^2}=\sqrt{\left(\frac{\mathrm{d}X_{B(t)}}{\mathrm{d}t}\right)^2 + \left(\frac{\mathrm{d}Y_{B(t)}}{\mathrm{d}t}\right)^2}\\
$$


Get the relationship between handles and the velocity of spaceships:
$$
|P_1 - P_2| = kV_1 \\
|P_3 - P_4| = kV_2
$$
Since $V_2$ is the velocity of spaceships when $t=1$,
$$
\frac{\mathrm{d}X_{B(t)}}{\mathrm{d}t}\Bigm|_{t=1}=3t^2X_4+[6t(t-1)+3t^2]X_3+[3(t-1)^2+3t\times2(t-1)]X_2+3(t-1)^2X1 \\
=3X_4 + 3X_3 \\
\frac{\mathrm{d}Y_{B(t)}}{\mathrm{d}t}\Bigm|_{t=1}=3Y_4 + 3Y_3
$$
So, 
$$
V_2=\sqrt{(3X_4 + 3X_3)^2+(3Y_4 + 3Y_3)^2}\\
=\sqrt{9(X_4 + X_3)^2+9(Y_4 + Y_3)^2}\\
=3\sqrt{(X_4 + X_3)^2+(Y_4 + Y_3)^2} \\
=3\sqrt{(X_4 -(- X_3))^2+(Y_4 -(- Y_3))^2} \\
=3|P_4-(-P_3)| \\
=3|P_4+P_3|
$$
therefore,
$$
k = \frac{|P_3-P_4|}{3|P_4+P_3|}\\
$$
