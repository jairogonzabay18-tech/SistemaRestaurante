# Entidad Empleado

## Propósito

La entidad `Empleado` es una clase abstracta que representa a los trabajadores del restaurante. Sirve como clase base para diferentes tipos de empleados (Mesero y Cocinero) y hereda de la clase `Persona`. Su propósito es gestionar la información común de todos los empleados del sistema, incluyendo datos personales, salarios, turnos y cálculos de bonificaciones.

## Ubicación en el Código

- **Archivo**: `Entidades/Empleado.cs`
- **Namespace**: `SistemaRestaurante.Entidades`
- **Tipo**: Clase abstracta que hereda de `Persona`

## Atributos

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| `idEmpleado` | `int` | Identificador único del empleado |
| `salario` | `decimal` | Salario base del empleado |
| `turno` | `string` | Turno de trabajo (Mañana, Tarde, Noche) |
| `fechaContrato` | `DateTime` | Fecha de contratación del empleado |

### Atributos Heredados de Persona

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| `id` | `int` | Identificador de la persona |
| `nombre` | `string` | Nombre del empleado |
| `apellido` | `string` | Apellido del empleado |
| `telefono` | `string` | Número telefónico |
| `email` | `string` | Correo electrónico |
| `fechaNacimiento` | `DateTime` | Fecha de nacimiento |

## Propiedades (Properties)

```csharp
public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
public decimal Salario { get => salario; set => salario = value; }
public string Turno { get => turno; set => turno = value; }
public DateTime FechaContrato { get => fechaContrato; set => fechaContrato = value; }
```

Todas las propiedades incluyen getters y setters para acceso completo a los atributos privados.

## Constructores

### Constructor Vacío
```csharp
public Empleado()
{
}
```

### Constructor Parametrizado
```csharp
public Empleado(int id, string nombre, string apellido,
                 string telefono, string email,
                 DateTime fechaNacimiento,
                 int idEmpleado,
                 decimal salario,
                 string turno,
                 DateTime fechaContrato)
    : base(id, nombre, apellido, telefono, email, fechaNacimiento)
{
    this.idEmpleado = idEmpleado;
    this.salario = salario;
    this.turno = turno;
    this.fechaContrato = fechaContrato;
}
```

Inicializa todos los atributos del empleado, incluyendo los heredados de la clase `Persona`.

## Métodos

### BonoAntiguedad()
```csharp
public decimal BonoAntiguedad()
{
    int anios = DateTime.Now.Year - FechaContrato.Year;
    return anios >= 5 ? 150m : 0m;
}
```

**Descripción**: Calcula un bono por antigüedad del empleado.
- Si el empleado tiene 5 o más años de antigüedad: retorna 150m
- Si el empleado tiene menos de 5 años: retorna 0m

**Parámetros**: Ninguno
**Retorna**: `decimal` - Monto del bono

### CalcularSalario()
```csharp
public abstract decimal CalcularSalario();
```

**Descripción**: Método abstracto que debe ser implementado por las subclases para calcular el salario total del empleado.
**Parámetros**: Ninguno
**Retorna**: `decimal` - Salario total calculado

### ObtenerRol()
```csharp
public abstract override string ObtenerRol();
```

**Descripción**: Método abstracto que retorna el rol específico del empleado.
**Parámetros**: Ninguno
**Retorna**: `string` - Rol del empleado (implementado en subclases)

### ObtenerInfo()
```csharp
public abstract override string ObtenerInfo();
```

**Descripción**: Método abstracto que retorna la información completa del empleado en formato de texto.
**Parámetros**: Ninguno
**Retorna**: `string` - Información formateada del empleado (implementado en subclases)

## Subclases

### Mesero

Hereda de `Empleado` y representa a los meseros del restaurante.

**Atributos específicos:**
- `mesasAsignadas` (int): Número de mesas asignadas
- `propinas` (decimal): Monto de propinas recibidas

**Implementación de CalcularSalario()**:
```csharp
public override decimal CalcularSalario()
{
    return Salario + Propinas + BonoAntiguedad();
}
```

**Implementación de ObtenerRol()**:
```csharp
public override string ObtenerRol()
{
    return "Mesero";
}
```

**Implementación de ObtenerInfo()**:
```csharp
public override string ObtenerInfo()
{
    return "MESERO\n" +
           "Nombre: " + NombreCompleto() + "\n" +
           "Turno: " + Turno + "\n" +
           "Mesas Asignadas: " + MesasAsignadas + "\n" +
           "Propinas: $" + Propinas + "\n" +
           "Salario Total: $" + CalcularSalario();
}
```

### Cocinero

Hereda de `Empleado` y representa a los cocineros del restaurante.

**Atributos específicos:**
- `especialidad` (string): Especialidad culinaria (ej: Parrilla, Comida Ecuatoriana)
- `experiencia` (int): Años de experiencia

**Métodos específicos:**
```csharp
public decimal BonoExperiencia()
{
    return Experiencia >= 5 ? 200m : 50m;
}
```

**Implementación de CalcularSalario()**:
```csharp
public override decimal CalcularSalario()
{
    return Salario + BonoExperiencia() + BonoAntiguedad();
}
```

**Implementación de ObtenerRol()**:
```csharp
public override string ObtenerRol()
{
    return "Cocinero";
}
```

**Implementación de ObtenerInfo()**:
```csharp
public override string ObtenerInfo()
{
    return "COCINERO\n" +
           "Nombre: " + NombreCompleto() + "\n" +
           "Especialidad: " + Especialidad + "\n" +
           "Experiencia: " + Experiencia + " años\n" +
           "Turno: " + Turno + "\n" +
           "Salario Total: $" + CalcularSalario();
}
```

## Operaciones CRUD

Las operaciones CRUD para empleados se manejan a través de la clase controladora `TLista`:

### Almacenamiento

```csharp
public static List<Mesero> ListaMeseros = new List<Mesero>();
public static List<Cocinero> ListaCocineros = new List<Cocinero>();
```

### Create (Crear)

```csharp
// Crear y añadir un mesero
TLista.ListaMeseros.Add(new Mesero(1, "Pedro", "Ruiz", "0996666666", "pedro@gmail.com", 
                                    new DateTime(1994, 3, 12), 201, 800m, "Mañana", 
                                    new DateTime(2021, 5, 10), 5, 120m));

// Crear y añadir un cocinero
TLista.ListaCocineros.Add(new Cocinero(3, "Ana", "Vera", "0998888888", "ana@gmail.com", 
                                        new DateTime(1988, 4, 15), 301, 1200m, "Mañana", 
                                        new DateTime(2018, 2, 10), "Comida Ecuatoriana", 8));
```

### Read (Leer)

**Listar Meseros:**
```csharp
dataGridView1.DataSource = TLista.ListaMeseros.ToList();
```

**Listar Cocineros:**
```csharp
dataGridView1.DataSource = TLista.ListaCocineros.ToList();
```

**Listar Todos:**
```csharp
var lista = TLista.ListaMeseros
    .Cast<object>()
    .Concat(TLista.ListaCocineros.Cast<object>())
    .ToList();
dataGridView1.DataSource = lista;
```

### Update (Actualizar)

Los empleados pueden ser modificados directamente a través de sus propiedades:

```csharp
TLista.ListaMeseros[0].Salario = 850m;
TLista.ListaMeseros[0].Turno = "Tarde";
TLista.ListaCocineros[0].Experiencia = 9;
```

### Delete (Eliminar)

```csharp
TLista.ListaMeseros.RemoveAt(index);
TLista.ListaCocineros.RemoveAt(index);
```

## Formulario Relacionado

### frmEmpleados

**Ubicación**: `Formularios/frmEmpleados.cs`

**Componentes UI:**
- **ComboBox**: Selector para filtrar por tipo de empleado (Mesero, Cocinero)
- **DataGridView**: Tabla para mostrar la lista de empleados
- **Botón "Ver información"**: Muestra los detalles completos del empleado seleccionado

**Métodos Principales:**

```csharp
public void ListarMeseros()
{
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = TLista.ListaMeseros.ToList();
}
```

```csharp
public void ListarCocineros()
{
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = TLista.ListaCocineros.ToList();
}
```

```csharp
public void ListarTodos()
{
    dataGridView1.DataSource = null;
    var lista = TLista.ListaMeseros
        .Cast<object>()
        .Concat(TLista.ListaCocineros.Cast<object>())
        .ToList();
    dataGridView1.DataSource = lista;
}
```

**Evento del Botón de Información:**

```csharp
private void button1_Click(object sender, EventArgs e)
{
    if (dataGridView1.CurrentRow != null)
    {
        object obj = dataGridView1.CurrentRow.DataBoundItem;

        if (obj is Mesero m)
        {
            MessageBox.Show(m.ObtenerInfo(), "Información Mesero");
        }

        if (obj is Cocinero c)
        {
            MessageBox.Show(c.ObtenerInfo(), "Información Cocinero");
        }
    }
}
```

**Evento ComboBox (Cambio de filtro):**

```csharp
private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
{
    if (comboBox1.SelectedItem.ToString() == "Mesero")
    {
        ListarMeseros();
    }
    else if (comboBox1.SelectedItem.ToString() == "Cocinero")
    {
        ListarCocineros();
    }
}
```

## Funcionamiento dentro del Sistema

### Integración con el Menú Principal

El formulario de empleados es accesible desde el menú principal (`frmMenu.cs`) a través de la opción "Empleados":

```csharp
private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
{
    frmEmpleados frm = new frmEmpleados();
    AbrirFormulario(frm);
}
```

### Carga de Datos Iniciales

Los empleados se cargan en la memoria durante la inicialización del sistema (`frmMenu.CargarDatos`):

```csharp
// MESEROS
TLista.ListaMeseros.Add(new Mesero(1, "Pedro", "Ruiz", "0996666666", "pedro@gmail.com", 
                                    new DateTime(1994, 3, 12), 201, 800m, "Mañana", 
                                    new DateTime(2021, 5, 10), 5, 120m));

// COCINEROS
TLista.ListaCocineros.Add(new Cocinero(3, "Ana", "Vera", "0998888888", "ana@gmail.com", 
                                        new DateTime(1988, 4, 15), 301, 1200m, "Mañana", 
                                        new DateTime(2018, 2, 10), "Comida Ecuatoriana", 8));
```

### Relación con Otras Entidades

**Pedido**: Los empleados (meseros específicamente) están asociados con los pedidos para registrar quién tomó el pedido:

```csharp
public class Pedido
{
    public Mesero Mesero { get => mesero; set => mesero = value; }
    // ...
}
```

### Flujo de Operación

1. **Inicio**: Se carga el menú principal y se inicializa la base de datos en memoria
2. **Selección**: El usuario selecciona "Empleados" del menú
3. **Visualización**: Se abre el formulario `frmEmpleados` mostrando los meseros por defecto
4. **Filtrado**: El usuario puede cambiar el filtro en el ComboBox para ver meseros o cocineros
5. **Información Detallada**: Al seleccionar un empleado y hacer clic en "Ver información", se muestra un MessageBox con los detalles completos
6. **Modificación**: Los datos pueden ser editados directamente en memoria (sin persistencia a base de datos en el código actual)

## Reglas de Negocio

1. **Bono por Antigüedad**: 
   - Si tiene ≥ 5 años: recibe $150
   - Si tiene < 5 años: recibe $0

2. **Bono por Experiencia (Cocineros)**:
   - Si tiene ≥ 5 años de experiencia: recibe $200
   - Si tiene < 5 años de experiencia: recibe $50

3. **Cálculo de Salario**:
   - **Mesero**: Salario Base + Propinas + Bono por Antigüedad
   - **Cocinero**: Salario Base + Bono por Experiencia + Bono por Antigüedad

4. **Turnos**: Los empleados trabajan en turnos específicos (Mañana, Tarde, Noche)
