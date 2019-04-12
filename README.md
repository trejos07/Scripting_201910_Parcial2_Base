# Scripting_201910_Parcial2_Base

#Patrones utilizados: 

-Singelton: para las piscinas de objetos, y gamemanaguer pues solo se debeseaba tener una instancia de ellos que sea accesible por cualquiera 
-Observador: para hacer control de los cambios de estado, muerte del los enemigos, colicion de los enemigos. se utilizo por que se deseaba conocer valores o realizar acciones desde otras clases, si necesidad de referencias directas
-Pool: para el control de la instanciacion de objetos como balas y enemigos ya que el enuciado pedia no instanciar y destruir constantemente
