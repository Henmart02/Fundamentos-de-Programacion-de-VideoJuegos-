# PasaPiezas

**PasaPiezas** es un juego 2D desarrollado en Unity con temática de ajedrez. El proyecto cuenta con un menú principal desde el cual el jugador puede acceder a tres opciones principales: **Pasa Piezas**, **Partida Rápida** y **Tutorial**.

El objetivo del juego es ofrecer una experiencia basada en tableros, piezas, turnos y movimientos estratégicos. En el modo **Pasa Piezas**, la mecánica se basa en una modalidad 2 vs 2 con dos tableros, donde las piezas capturadas pueden pasar a un compañero. En el modo **Partida Rápida**, se desarrolla una partida normal de ajedrez 1 vs 1 de forma local. El modo **Tutorial** permite practicar los movimientos de las piezas de ajedrez.

---

## Integrantes y roles

| Integrante                       | Rol             | Carnet   |
| -------------------------------- | --------------- | -------- |
| Henry Saul Martínez Flores       | Programador     | 00012622 |
| Carlos Armando Ordoñez Cruz      | Diseño          | 00072122 |
| José Alfredo Rodríguez Rodríguez | Game Designer   | 00055421 |
| Eduardo Antonio Ayala Chavez     | Project Manager | 00091722 |

---

## Tecnologías utilizadas

* Unity 6
* C#
* TextMeshPro
* Sprites 2D
* Sistema de escenas de Unity
* Audio importado en Unity
* Git y GitHub para control de versiones

---

## Modos de juego

### Pasa Piezas

Modo principal del juego. Se juega con dos tableros y está pensado para una modalidad en dúos. La mecánica principal consiste en capturar piezas y pasarlas al compañero para apoyar su partida.

### Partida Rápida

Modo de ajedrez local 1 vs 1. Permite que dos jugadores jueguen una partida normal utilizando piezas blancas y negras.

### Tutorial

Modo diseñado para que el jugador aprenda y practique los movimientos de las piezas de ajedrez, como peón, torre, caballo, alfil, dama y rey.

---

## Estructura del proyecto

```text
PasaPiezas/
│
├── Assets/
│   ├── Audio/
│   ├── Materials/
│   ├── Prefabs/
│   ├── Resources/
│   ├── Scenes/
│   ├── Scripts/
│   ├── Sprites/
│   └── TextMesh Pro/
│
├── Packages/
├── ProjectSettings/
└── README.md
```

---

## Carpetas principales

### Assets/Audio

Contiene los sonidos y canciones utilizados en el juego, como música de fondo, sonidos de botones, sonidos de movimiento, victoria, derrota y otros efectos de retroalimentación.

### Assets/Materials

Contiene los materiales usados para mantener una apariencia visual coherente en el proyecto, principalmente relacionados con tonos azules, negros, blancos y grises.

### Assets/Prefabs

Contiene objetos reutilizables del juego, como piezas, casillas, botones, tableros o elementos de interfaz.

### Assets/Scenes

Contiene las escenas principales del juego:

```text
MainMenu.unity
MainScene.unity
QuickMatchScene.unity
```

* **MainMenu:** escena del menú principal.
* **MainScene:** escena del modo Pasa Piezas.
* **QuickMatchScene:** escena del modo Partida Rápida.

### Assets/Scripts

Contiene los scripts que controlan la lógica del juego, navegación, tableros, piezas, audio, interfaz y condiciones de finalización.

Scripts principales:

```text
MainMenuManager.cs
SettingsManager.cs
GameManager.cs
BughouseManager.cs
EndGameManager.cs
PopupManager.cs
QuickMatchUIManager.cs
AudioManager.cs
BoardManager.cs
PieceController.cs
```

### Assets/Sprites

Contiene las imágenes del juego, incluyendo fondos, botones, piezas de ajedrez, elementos de menú, interfaz y tutorial.

---

## Assets principales del juego

El proyecto utiliza diferentes tipos de assets:

* Piezas blancas y negras de ajedrez.
* Fondos 2D con temática tecnológica.
* Botones de menú y botones de partida.
* Textos de interfaz.
* Tableros de ajedrez.
* Casillas del tablero.
* Sonidos y música.
* Scripts de control.
* Animaciones de selección, movimiento, captura y transición.

---

## Controles

El juego se controla principalmente con mouse.

| Acción            | Control                        |
| ----------------- | ------------------------------ |
| Mover cursor      | Mouse                          |
| Seleccionar botón | Clic izquierdo                 |
| Seleccionar pieza | Clic izquierdo sobre una pieza |
| Mover pieza       | Clic sobre una casilla válida  |
| Rendirse          | Botón Rendirse                 |
| Deshacer jugada   | Botón Deshacer                 |
| Solicitar tablas  | Botón Tablas                   |
| Volver al menú    | Botón Volver                   |

---

## Funcionalidades principales

* Menú principal interactivo.
* Modo Pasa Piezas 2 vs 2.
* Modo Partida Rápida 1 vs 1.
* Tutorial de movimientos.
* Sistema de tableros.
* Sistema de piezas.
* Botones de rendirse, deshacer y tablas.
* Fondos personalizados.
* Interfaz con TextMeshPro.
* Audio para mejorar la experiencia del jugador.

---

## Roles y aportes

### Henry Saul Martínez Flores — Programador

Encargado de implementar la lógica funcional del juego mediante scripts. Su trabajo se enfoca en la programación de escenas, tableros, piezas, movimientos, botones, navegación y condiciones de partida.

### Carlos Armando Ordoñez Cruz — Diseño

Encargado del diseño visual del proyecto. Su trabajo se enfoca en los fondos, botones, interfaz, estilo visual, colores, organización de elementos en pantalla y coherencia gráfica del juego.

### José Alfredo Rodríguez Rodríguez — Game Designer

Encargado de definir las reglas, mecánicas y experiencia del jugador. Su trabajo se enfoca en el funcionamiento del modo Pasa Piezas, el modo Partida Rápida, el tutorial, los turnos y las condiciones del juego.

### Eduardo Antonio Ayala Chavez — Project Manager

Encargado de organizar el desarrollo del proyecto. Su trabajo se enfoca en la coordinación del equipo, división de tareas, control de avances, revisión de entregables y organización general del repositorio.

---

## Cómo abrir el proyecto

1. Clonar el repositorio:

```bash
git clone URL_DEL_REPOSITORIO
```

2. Abrir Unity Hub.

3. Seleccionar **Open** o **Add project from disk**.

4. Elegir la carpeta del proyecto **PasaPiezas**.

5. Esperar a que Unity importe los archivos.

6. Abrir la escena principal:

```text
Assets/Scenes/MainMenu.unity
```

7. Presionar **Play** para probar el juego desde el menú principal.

---

## Recomendaciones para ejecutar

Antes de probar el juego, revisar que las escenas estén agregadas en Build Settings:

```text
File > Build Profiles / Build Settings > Scenes In Build
```

Escenas recomendadas:

```text
MainMenu
MainScene
QuickMatchScene
```

También se recomienda verificar que los objetos principales estén activos en cada escena:

```text
Main Camera
Canvas
EventSystem
GameManager
AudioManager
BoardA
BoardB
Background
PopupManager
EndGameManager
```

---

## Estado del proyecto

El proyecto cuenta con una base funcional de menú, escenas principales, fondos, interfaz, piezas, tableros y scripts para la lógica del juego. Se continúa trabajando en la mejora de controles, validaciones, sonidos, animaciones y corrección de errores.

---

## Notas

Este proyecto fue desarrollado como parte de la materia **Fundamentos de Programación de Videojuegos**.

La entrega incluye assets visuales, scripts, escenas, audio, estructuras de tablero, controles, objetos, animaciones y roles del equipo.
