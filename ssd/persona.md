# Entidad Persona

## 1. Propósito

La entidad **Persona** es una clase abstracta que representa la base fundamental de todas las personas en el sistema del restaurante. Esta clase establece los atributos y comportamientos comunes compartidos por cualquier persona que interactúe con el sistema, sin importar si es un cliente o un empleado.

La entidad es utilizada para:
- Definir información común a todas las personas (datos de identidad, contacto, nacimiento)
- Servir como clase base para otras entidades como `Empleado` y `Cliente`
- Proporcionar métodos genéricos aplicables a cualquier persona del sistema
- Calcular información derivada como edad y nombre completo

---

## 2. Atributos

### Atributos Principales

- **id** (int): Identificador único de la persona en el sistema
- **nombre** (string): Nombre de la persona
- **apellido** (string): Apellido de la persona
- **telefono** (string): Teléfono de contacto
- **email** (string): Correo electrónico de la persona
- **fechaNacimiento** (DateTime): Fecha de nacimiento de la persona

---

## 3. Métodos

### 3.1 Constructores

#### Constructor Vacío
```csharp
public Persona()
{
}
```
Constructor por defecto que inicializa una instancia vacía sin asignar valores a los atributos.

#### Constructor Parametrizado
```csharp
public Persona(int id, string nombre, string apellido,
               string telefono, string email,
               DateTime fechaNacimiento)
{
    this.id = id;
    this.nombre = nombre;
    this.apellido = apellido;
    this.telefono = telefono;
    this.email = email;
    this.fechaNacimiento = fechaNacimiento;
}
```

Inicializa todos los atributos de la persona con los parámetros proporcionados. Este constructor es la base para las subclases que heredan de `Persona`.

### 3.2 Propiedades (Getters y Setters)

#### Id
```csharp
public int Id { get => id; set => id = value; }
```
Permite obtener y establecer el identificador único de la persona.

#### Nombre
```csharp
public string Nombre { get => nombre; set => nombre = value; }
```
Permite obtener y establecer el nombre de la persona.

#### Apellido
```csharp
public string Apellido { get => apellido; set => apellido = value; }
```
Permite obtener y establecer el apellido de la persona.

#### Telefono
```csharp
public string Telefono { get => telefono; set => telefono = value; }
```
Permite obtener y establecer el teléfono de contacto.

#### Email
```csharp
public string Email { get => email; set => email = value; }
```
Permite obtener y establecer el correo electrónico de la persona.

#### FechaNacimiento
```csharp
public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
```
Permite obtener y establecer la fecha de nacimiento de la persona.

### 3.3 Métodos Concretos

#### NombreCompleto()
```csharp
public string NombreCompleto()
{
    return Nombre + " " + Apellido;
}
```

**Propósito:** Concatena y retorna el nombre y apellido de la persona en un formato de nombre completo.

**Retorna:** (string) Nombre y apellido separados por un espacio

**Ejemplo de uso:** Una persona con nombre "Juan" y apellido "Pérez" retorna "Juan Pérez"

#### Edad()
```csharp
public int Edad()
{
    int edad = DateTime.Now.Year - FechaNacimiento.Year;

    if (DateTime.Now.Month < FechaNacimiento.Month ||
       (DateTime.Now.Month == FechaNacimiento.Month &&
        DateTime.Now.Day < FechaNacimiento.Day))
    {
        edad--;
    }

    return edad;
}
```

**Propósito:** Calcula la edad actual de la persona basándose en su fecha de nacimiento.

**Lógica:** 
- Calcula la diferencia entre el año actual y el año de nacimiento
- Ajusta la edad si aún no ha pasado el cumpleaños en el año actual
- Verifica mes y día para determinar si ya ha cumplido años

**Retorna:** (int) Edad actual de la persona

**Ejemplo de uso:** Una persona nacida el 15 de agosto de 1995, en junio de 2026, tendría 30 años (2026 - 1995 = 31, pero se ajusta a 30 porque aún no ha pasado agosto)

#### ToString()
```csharp
public override string ToString()
{
    return NombreCompleto();
}
```

**Propósito:** Sobrescribe el método `ToString()` de la clase base para retornar el nombre completo de la persona.

**Retorna:** (string) Nombre completo de la persona

**Nota:** Este método es útil para mostrar personas en ComboBox, ListBox y otros controles que usan `ToString()` para visualización.

### 3.4 Métodos Abstractos

#### ObtenerRol()
```csharp
public abstract string ObtenerRol();
```

**Propósito:** Define un contrato que las subclases deben implementar para especificar el rol de la persona en el sistema.

**Nota:** Cada subclase (Cliente, Empleado, etc.) debe implementar este método para retornar su rol específico.

**Ejemplos de implementación:**
- Cliente: retorna "Cliente"
- Mesero: retorna "Mesero"
- Cocinero: retorna "Cocinero"

#### ObtenerInfo()
```csharp
public abstract string ObtenerInfo();
```

**Propósito:** Define un contrato que las subclases deben implementar para retornar la información formateada específica de cada tipo de persona.

**Nota:** Cada subclase es responsable de proporcionar su propia implementación con información relevante.

**Ejemplos de implementación:**
- Cliente: incluye nombre, teléfono, email, edad y puntos de fidelidad
- Mesero: incluye nombre, turno, mesas asignadas, propinas y salario total
- Cocinero: incluye nombre, especialidad, experiencia, turno y salario total

---

## 4. Jerarquía de Clases

La clase `Persona` se encuentra en la raíz de la jerarquía de clases del sistema:

```
Persona (abstract)
    ├── Empleado (abstract)
    │   ├── Mesero
    │   └── Cocinero
    └── Cliente
```

- **Persona**: Clase base abstracta con atributos comunes
- **Empleado**: Clase abstracta que extiende Persona, añadiendo atributos de empleado (salario, turno, etc.)
- **Mesero**: Clase concreta que extiende Empleado, especializada en meseros
- **Cocinero**: Clase concreta que extiende Empleado, especializada en cocineros
- **Cliente**: Clase concreta que extiende Persona directamente

---

## 5. Subclases Directas

### Cliente
```csharp
public class Cliente : Persona
{
    private int idCliente;
    private int puntosFidelidad;
    
    // Métodos específicos de Cliente
    public override string ObtenerRol() => "Cliente";
    public override string ObtenerInfo() => "...";
}
```

La clase Cliente hereda directamente de Persona y añade información específica de clientes como ID de cliente y puntos de fidelidad.

### Empleado (Clase Abstracta)
```csharp
public abstract class Empleado : Persona
{
    private int idEmpleado;
    private decimal salario;
    private string turno;
    private DateTime fechaContrato;
    
    public decimal BonoAntiguedad() { ... }
    public abstract decimal CalcularSalario();
    public abstract override string ObtenerRol();
    public abstract override string ObtenerInfo();
}
```

La clase Empleado hereda de Persona y añade atributos específicos de empleados. A su vez, es la clase base para Mesero y Cocinero.

---

## 6. Funcionamiento dentro del Sistema

### Flujo de Utilización

1. **Creación de Instancias:**
   - No se puede instanciar directamente `Persona` por ser abstracta
   - Se crean instancias de sus subclases concretas (Cliente, Mesero, Cocinero)
   - El constructor de `Persona` es llamado automáticamente a través de `base()`

2. **Herencia de Atributos:**
   - Todas las subclases heredan los 6 atributos de Persona
   - Las subclases pueden acceder a estos atributos mediante las propiedades públicas
   - Ejemplo: `cliente.Nombre`, `mesero.Email`, `cocinero.FechaNacimiento`

3. **Polimorfismo:**
   - Los métodos abstractos (ObtenerRol(), ObtenerInfo()) se implementan de forma específica en cada subclase
   - Los métodos concretos (NombreCompleto(), Edad(), ToString()) se heredan y usan igual en todas las subclases

### Ejemplo de Creación y Uso

```csharp
// 1. Crear un Cliente (instancia de subclase de Persona)
Cliente cliente = new Cliente(
    id: 1,
    nombre: "Juan",
    apellido: "Perez",
    telefono: "0991111111",
    email: "juan@gmail.com",
    fechaNacimiento: new DateTime(1995, 5, 10),
    idCliente: 101,
    puntosFidelidad: 10
);

// 2. Usar métodos heredados de Persona
string nombreCompleto = cliente.NombreCompleto();  // "Juan Perez"
int edad = cliente.Edad();                          // Calcula la edad actual
string info = cliente.ToString();                   // "Juan Perez"

// 3. Usar métodos específicos de subclase
string rol = cliente.ObtenerRol();                  // "Cliente"
string detalles = cliente.ObtenerInfo();            // Información completa del cliente

// 4. Acceso a propiedades heredadas
string email = cliente.Email;                       // "juan@gmail.com"
DateTime nacimiento = cliente.FechaNacimiento;      // 1995-05-10
```

### Uso en Formularios

La clase Persona actúa como puente entre la lógica de negocio y la presentación:

```csharp
// En frmClientes.cs
public Cliente CrearObjeto()
{
    // Utiliza el constructor parametrizado de Persona (vía Cliente)
    return new Cliente(
        int.Parse(textBox1.Text),      // id (de Persona)
        textBox2.Text,                  // nombre (de Persona)
        textBox3.Text,                  // apellido (de Persona)
        textBox4.Text,                  // telefono (de Persona)
        textBox5.Text,                  // email (de Persona)
        dateTimePicker1.Value,          // fechaNacimiento (de Persona)
        int.Parse(textBox1.Text),       // idCliente (de Cliente)
        int.Parse(textBox6.Text)        // puntosFidelidad (de Cliente)
    );
}
```

---

## 7. Características Clave

### Abstracción
- Persona no puede ser instanciada directamente
- Fuerza a las subclases a implementar métodos abstractos
- Define una interfaz común para todas las personas del sistema

### Reutilización de Código
- Los métodos `NombreCompleto()`, `Edad()` y `ToString()` se heredan a todas las subclases
- Evita duplicación de código en Cliente, Mesero y Cocinero
- Cambios en estos métodos se aplicarán automáticamente a todas las subclases

### Extensibilidad
- Nuevas personas (Admin, Gerente, etc.) pueden heredar de Persona o Empleado
- Mantiene la estructura coherente del sistema
- Facilita agregar nuevas funcionalidades comunes

### Polimorfismo
- Métodos abstractos permiten comportamiento específico por tipo de persona
- El mismo código puede trabajar con diferentes tipos de personas
- Ejemplo: Mostrar información diferente según el tipo de persona

---

## 8. Cálculo de Edad

El cálculo de edad es una característica importante que merece destacarse:

```csharp
// Paso 1: Calcula diferencia de años
int edad = DateTime.Now.Year - FechaNacimiento.Year;  // 2026 - 1995 = 31

// Paso 2: Verifica si ya cumplió años este año
if (DateTime.Now.Month < FechaNacimiento.Month ||           // Si no ha llegado el mes
    (DateTime.Now.Month == FechaNacimiento.Month && 
     DateTime.Now.Day < FechaNacimiento.Day))              // O está en el mes pero no el día
{
    edad--;  // Reduce en 1 si aún no ha cumplido
}
```

**Ejemplo:**
- Persona nacida: 15 de agosto de 1995
- Fecha actual: 10 de junio de 2026
- Cálculo: 2026 - 1995 = 31, pero como junio < agosto, restamos 1 → Edad = 30

---

## 9. Integración con el Sistema

### Almacenamiento
Persona no se almacena directamente. Sus subclases se almacenan en:
- `TListaCliente.Lista` - para instancias de Cliente
- `TLista.ListaMeseros` - para instancias de Mesero (que heredan de Empleado)
- `TLista.ListaCocineros` - para instancias de Cocinero (que heredan de Empleado)

### Visualización
- Los métodos heredados de Persona se usan en DataGridView
- La propiedad `ToString()` se usa en ComboBox y ListBox
- El método `ObtenerInfo()` se usa para mostrar detalles en MessageBox

### Cálculos
- El método `Edad()` se usa en formularios y reportes
- El método `NombreCompleto()` se usa en comprobantes y listas
- Métodos derivados (como `CalcularSalario()` en Empleado) dependen de atributos de Persona

---

## 10. Resumen

La entidad **Persona** es fundamental en el Sistema Restaurante porque:
- Proporciona una base común para todas las personas del sistema
- Define atributos e información compartida (nombre, email, teléfono, etc.)
- Implementa métodos útiles como cálculo de edad y nombre completo
- Establece contratos (métodos abstractos) para comportamientos específicos
- Facilita la herencia y reutilización de código en subclases
- Permite el polimorfismo para manejar diferentes tipos de personas de forma uniforme
- Simplifica la estructura del código y mejora la mantenibilidad del sistema
