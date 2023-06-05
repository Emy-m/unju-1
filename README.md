# Parte 2

## 2.a. Crear un script teniendo en cuenta el formato del nombre para el script

    Se creo el script GameManager

## 2.b. De acuerdo a los nombres de las variables

    Se agregaron las variables al script

## 2.c. ¿En cuál de los siguientes métodos, que corresponden al ciclo de vida de un GameObject, es conveniente inicializar variables?

    Start()

## 2.d. Modifique el script creado en clase, agregue una variable para manipular la velocidad del desplazamiento del personaje (Homero)

    En el script Player, que se aplica a Homero, se agrego la variable speed
    var maxSpeed = GameManager.Instance.SpeedMax;
    var direction = Input.GetAxis("Horizontal");
    var velocity = Mathf.Clamp(direction * speed, -maxSpeed, maxSpeed);
    rb.velocity = new Vector2(velocity, transform.position.y);

## 2.e. Modifique la lógica de instanciación de ítems u objetos dentro de la escena del videojuego, para que al caer lo hagan con una velocidad aleatoria, modifique el modificador de acceso a privado pero permita visualizar la variable velocidad (speed) en el inspector.

    En el script Item, se agrego la variable Speed, MaxSpeed y MinSpeed
    void Start()
    {
        Speed = Random.Range(MinSpeed, MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -Speed);
    }

    Entonces desde el GameManager se puede modificar MaxSpeed para que los items caigan mas rapido o mas lento
