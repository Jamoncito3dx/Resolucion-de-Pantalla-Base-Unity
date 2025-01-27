# Unity Resolution Settings

Este proyecto contiene un script de Unity que permite configurar las resoluciones de pantalla utilizando un Dropdown de TextMeshPro (TMP). Es útil para implementar configuraciones gráficas en videojuegos desarrollados con Unity.

## 📋 Características

- Detecta automáticamente todas las resoluciones compatibles con el dispositivo.
- Muestra las resoluciones disponibles en un Dropdown de TMP.
- Permite cambiar la resolución y la frecuencia de actualización (Hz) en tiempo real.
- Manejo de errores en caso de no asignar el componente TMP Dropdown.

## 🛠️ Requisitos

- **Unity** (versión recomendada: 2021.3 o superior).
- **TextMeshPro**: Asegúrate de que el paquete TextMeshPro esté instalado en tu proyecto de Unity.

## 🚀 Cómo usar el script

1. **Agregar el script al proyecto:**
   - Copia el archivo `ResolutionSettings.cs` y colócalo en la carpeta `Scripts` de tu proyecto de Unity.

2. **Configurar el componente TMP Dropdown:**
   - Crea un objeto `Canvas` en tu escena (si no existe).
   - Añade un componente `TMP Dropdown` a tu interfaz gráfica.
   - Asigna el Dropdown al campo público `resolutionDropdown` en el Inspector del objeto que contiene este script.

3. **Ejecutar el proyecto:**
   - Al iniciar el juego, el Dropdown mostrará las resoluciones disponibles. Selecciona una resolución para aplicarla en tiempo real.

## 📂 Estructura del proyecto

```plaintext
UnityResolutionSettings/
├── ResolutionSettings.cs   # Script principal para gestionar resoluciones.
├── README.md               # Documentación del proyecto.
