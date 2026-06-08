# Entidad Mesero

## 1. Propósito

La entidad **Mesero** representa a los meseros que laboran en el restaurante. Esta clase hereda de la clase abstracta `Empleado`, especializando el comportamiento de los empleados para gestionar las responsabilidades específicas de un mesero, como la asignación de mesas y el registro de propinas.

La entidad es utilizada para:
- Registrar información de los meseros del restaurante
- Asociar meseros con pedidos para identificar quién toma cada pedido
- Calcular el salario considerando propinas y bonificaciones por antigüedad
- Gestionar la cantidad de mesas asignadas a cada mesero

---

## 2. Atributos

### Atributos Heredados (de Empleado)
- **id** (int): Identificador único de la persona
- **nombre** (string): Nombre del mesero
- **apellido** (string): Apellido del mesero
- **telefono** (string): Teléfono de contacto
- **email** (string): Correo electrónico
- **fechaNacimiento** (DateTime): Fecha de nacimiento
- **idEmpleado** (int): Identificador del empleado
- **salario** (decimal): Salario base del mesero
- **turno** (string): Turno de trabajo (Mañana, Tarde, Noche)
- **fechaContrato** (DateTime): Fecha de contratación

### Atributos Específicos de Mesero
- **mesasAsignadas** (int): Número de mesas asignadas al mesero
- **propinas** (decimal): Monto total de propinas recibidas

---

## 3. Métodos

### 3.1 Constructores

#### Constructor Vacío
```csharp
public Mesero()
{
}
```
Constructor por defecto que inicializa una instancia vacía.

#### Constructor Parametrizado
```csharp
public Mesero(int id, string nombre, string apellido,
              string telefono, string email,
              DateTime fechaNacimiento,
              int idEmpleado,
              decimal salario,
              string turno,
              DateTime fechaContrato,
              int mesasAsignadas,
              decimal propinas)
```
Inicializa un mesero con todos sus parámetros:
- Los primeros 10 parámetros son pasados a la clase base `Empleado`
- Los últimos dos parámetros (`mesasAsignadas` y `propinas`) se asignan a los atributos específicos

### 3.2 Propiedades (Getters y Setters)

#### MesasAsignadas
```csharp
public int MesasAsignadas 
{ 
    get => mesasAsignadas; 
    set => mesasAsignadas = value; 
}
```
Permite obtener y establecer el número de mesas asignadas al mesero.

#### Propinas
```csharp
public decimal Propinas 
{ 
    get => propinas; 
    set => propinas = value; 
}
```
Permite obtener y establecer el monto de propinas recibidas.

### 3.3 Métodos Sobrescritos (Override)

#### CalcularSalario()
```csharp
public override decimal CalcularSalario()
{
    return Salario + Propinas + BonoAntiguedad();
}
```

**Propósito:** Calcula el salario total del mesero sumando:
- Salario base (heredado de Empleado)
- Propinas recibidas
- Bono por antigüedad (si tiene 5 o más años de antigüedad, recibe $150)

**Retorna:** (decimal) Salario total calculado

#### ObtenerRol()
```csharp
public override string ObtenerRol()
{
    return "Mesero";
}
```

**Propósito:** Retorna el rol del empleado identificándolo como "Mesero"

**Retorna:** (string) "Mesero"

#### ObtenerInfo()
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

**Propósito:** Retorna una representación formateada de la información del mesero para visualización.

**Retorna:** (string) Cadena con formato que contiene:
- Identificación como "MESERO"
- Nombre completo del mesero
- Turno asignado
- Número de mesas asignadas
- Monto de propinas
- Salario total calculado

---

## 4. Operaciones CRUD

Las operaciones CRUD para la entidad Mesero se realizan a través de la clase controladora `TLista`, que mantiene una lista estática de meseros en memoria.

### Create (Crear)
```csharp
// En frmMenu.cs - CargarDatos()
TLista.ListaMeseros.Add(new Mesero(1, "Pedro", "Ruiz", "0996666666", "pedro@gmail.com", 
                                    new DateTime(1994, 3, 12), 201, 800m, "Mañana", 
                                    new DateTime(2021, 5, 10), 5, 120m));
TLista.ListaMeseros.Add(new Mesero(2, "Luis", "Torres", "0997777777", "luis@gmail.com", 
                                    new DateTime(1996, 7, 8), 202, 850m, "Tarde", 
                                    new DateTime(2022, 1, 15), 4, 150m));
```

Los meseros se crean instanciando la clase `Mesero` con sus parámetros y agregándolos a `TLista.ListaMeseros`.

### Read (Leer)
```csharp
// En frmEmpleados.cs - ListarMeseros()
public void ListarMeseros()
{
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = TLista.ListaMeseros.ToList();
}
```

Se consultan los meseros obteniendo la lista desde `TLista.ListaMeseros` y mostrándola en un DataGridView.

### Update (Actualizar)
```csharp
// Los meseros se actualizan modificando sus propiedades
Mesero mesero = TLista.ListaMeseros[0];
mesero.MesasAsignadas = 6;
mesero.Propinas = 200m;
mesero.Turno = "Tarde";
```

Las actualizaciones se realizan directamente sobre la referencia del objeto, accediendo a sus propiedades.

### Delete (Eliminar)
```csharp
// Eliminación de la lista
TLista.ListaMeseros.RemoveAt(0);  // Por índice
// O
TLista.ListaMeseros.Remove(mesero);  // Por referencia
```

Se utilizan los métodos de List<T> para remover elementos.

---

## 5. Formularios Relacionados

### frmEmpleados (Formularios/frmEmpleados.cs)

Este es el formulario principal para gestionar empleados (meseros y cocineros).

**Componentes:**
- **ComboBox (comboBox1)**: Permite filtrar entre "Mesero" y "Cocinero"
- **DataGridView (dataGridView1)**: Muestra la lista de meseros seleccionados
- **Button (button1)**: Muestra la información detallada del mesero seleccionado

**Métodos principales:**

```csharp
public void ListarMeseros()
{
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = TLista.ListaMeseros.ToList();
}
```
Carga y muestra la lista de todos los meseros en el DataGridView.

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
    }
}
```
Al seleccionar un mesero y hacer clic en el botón de información, muestra un MessageBox con los detalles completos del mesero utilizando el método `ObtenerInfo()`.

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
Permite filtrar la lista según el tipo de empleado seleccionado.

### frmPedidos (Formularios/frmPedidos.cs)

Este formulario se utiliza para crear y gestionar pedidos, donde los meseros juegan un papel central.

**Uso de Mesero en este formulario:**

```csharp
public void CargarCombos()
{
    // ... otros combos ...
    comboBox2.DataSource = null;
    comboBox2.DataSource = TLista.ListaMeseros;
    comboBox2.DisplayMember = "Nombre";
}
```
Se carga un ComboBox con la lista de meseros disponibles para asociar con cada pedido.

```csharp
public Pedido CrearObjeto()
{
    // ... otros parámetros ...
    Mesero mesero = (Mesero)comboBox2.SelectedItem;
    
    return new Pedido(
        idPedido,
        cliente,
        mesero,      // Se asigna el mesero seleccionado
        mesa,
        plato,
        // ... otros parámetros ...
    );
}
```
Al crear un pedido, se selecciona el mesero responsable desde el ComboBox.

---

## 6. Funcionamiento dentro del Sistema

### Flujo de Inicialización

1. **Carga de Datos** (`frmMenu.CargarDatos()`):
   - Al iniciar la aplicación, se crea el menú principal
   - En el método `CargarDatos()`, se crean instancias de meseros y se agregan a `TLista.ListaMeseros`
   - Los datos se mantienen en memoria durante toda la sesión

2. **Acceso al Formulario de Empleados**:
   ```csharp
   private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
   {
       frmEmpleados frm = new frmEmpleados();
       AbrirFormulario(frm);
   }
   ```
   El usuario selecciona la opción "Empleados" del menú principal

### Relación con Otras Entidades

**Pedido**: La relación principal de Mesero es con la entidad `Pedido`
```csharp
public class Pedido
{
    private Mesero mesero;
    public Mesero Mesero { get => mesero; set => mesero = value; }
    
    public string ImprimirPedido()
    {
        return "PEDIDO\n" +
               // ...
               "Mesero: " + Mesero.NombreCompleto() + "\n" +
               // ...
    }
}
```

- Cada pedido debe tener asociado un mesero
- El mesero es responsable de tomar el pedido del cliente
- En el comprobante del pedido se incluye el nombre del mesero

### Jerarquía de Clases

```
Persona (abstract)
    └── Empleado (abstract)
            ├── Mesero
            └── Cocinero
```

### Ciclo de Vida de un Mesero en la Aplicación

1. **Creación**: Se instancia durante la carga de datos inicial
2. **Almacenamiento**: Se mantiene en la lista `TLista.ListaMeseros`
3. **Visualización**: Se puede ver en `frmEmpleados` filtrando por tipo de empleado
4. **Asociación**: Se selecciona al crear un pedido en `frmPedidos`
5. **Cálculo**: Se calculan sus propinas y salario según los pedidos atendidos
6. **Consulta**: Se puede ver su información detallada mediante `ObtenerInfo()`

### Ejemplo de Uso Completo

```csharp
// 1. Crear un mesero
Mesero mesero = new Mesero(
    id: 1,
    nombre: "Pedro",
    apellido: "Ruiz",
    telefono: "0996666666",
    email: "pedro@gmail.com",
    fechaNacimiento: new DateTime(1994, 3, 12),
    idEmpleado: 201,
    salario: 800m,
    turno: "Mañana",
    fechaContrato: new DateTime(2021, 5, 10),
    mesasAsignadas: 5,
    propinas: 120m
);

// 2. Agregar a la lista global
TLista.ListaMeseros.Add(mesero);

// 3. Usar en un pedido
Pedido pedido = new Pedido(..., mesero, ...);

// 4. Actualizar propinas
mesero.Propinas += 25m;

// 5. Calcular salario total
decimal salarioTotal = mesero.CalcularSalario();  // 800 + 145 + 150 = 1095

// 6. Obtener información
string info = mesero.ObtenerInfo();
```

---

## 7. Resumen

La entidad **Mesero** es un componente fundamental del Sistema Restaurante que:
- Representa a los meseros del establecimiento
- Hereda comportamiento de `Empleado` y `Persona`
- Gestiona información específica de meseros (mesas asignadas, propinas)
- Se integra con el formulario `frmEmpleados` para visualización
- Se asocia con `Pedido` para identificar quién atiende cada solicitud
- Calcula salarios incluyendo propinas y bonificaciones por antigüedad
- Mantiene los datos en memoria en la lista estática `TLista.ListaMeseros`
