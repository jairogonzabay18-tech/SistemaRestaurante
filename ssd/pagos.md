# Entidad Pago

## Propósito

La entidad `Pago` representa los pagos realizados por los clientes del restaurante. Registra la información relacionada con transacciones de dinero, incluyendo el pedido asociado, el monto pagado, el método de pago utilizado y el estado del pago. Esta entidad es fundamental para la gestión financiera del restaurante.

## Ubicación en el Código

- **Archivo**: `Entidades/Pago.cs`
- **Namespace**: `SistemaRestaurante.Entidades`
- **Tipo**: Clase pública

## Atributos

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| `idPago` | `int` | Identificador único del pago |
| `pedido` | `Pedido` | Referencia al pedido asociado al pago |
| `monto` | `decimal` | Monto pagado por el cliente |
| `metodoPago` | `string` | Método de pago utilizado (Efectivo, Tarjeta, etc.) |
| `fechaPago` | `DateTime` | Fecha y hora en que se registró el pago |
| `pagado` | `bool` | Estado del pago (True: procesado, False: pendiente) |

## Propiedades (Properties)

```csharp
public int IdPago { get => idPago; set => idPago = value; }
public Pedido Pedido { get => pedido; set => pedido = value; }
public decimal Monto { get => monto; set => monto = value; }
public string MetodoPago { get => metodoPago; set => metodoPago = value; }
public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
public bool Pagado { get => pagado; set => pagado = value; }
```

Todas las propiedades incluyen getters y setters para acceso completo a los atributos privados.

## Constructores

### Constructor Vacío
```csharp
public Pago()
{
}
```

### Constructor Parametrizado
```csharp
public Pago(int idPago, Pedido pedido,
            decimal monto, string metodoPago,
            DateTime fechaPago, bool pagado)
{
    this.idPago = idPago;
    this.pedido = pedido;
    this.monto = monto;
    this.metodoPago = metodoPago;
    this.fechaPago = fechaPago;
    this.pagado = pagado;
}
```

Inicializa todos los atributos del pago con los valores proporcionados.

## Métodos

### ProcesarPago()
```csharp
public bool ProcesarPago()
{
    if (Monto > 0)
    {
        Pagado = true;
        return true;
    }

    return false;
}
```

**Descripción**: Valida y procesa el pago del cliente.
- Si el monto es mayor a 0: marca el pago como procesado (Pagado = true) y retorna true
- Si el monto es 0 o menor: retorna false sin procesar el pago

**Parámetros**: Ninguno
**Retorna**: `bool` - True si el pago fue procesado exitosamente, False en caso contrario

### GenerarRecibo()
```csharp
public string GenerarRecibo()
{
    return "RECIBO DE PAGO\n" +
           "Código Pago: " + IdPago + "\n" +
           "Pedido: " + Pedido.IdPedido + "\n" +
           "Monto: $" + Monto + "\n" +
           "Método de Pago: " + MetodoPago + "\n" +
           "Fecha: " + FechaPago + "\n" +
           "Estado: " + Pagado;
}
```

**Descripción**: Genera un recibo de pago formateado en texto que muestra los detalles completos de la transacción.
**Parámetros**: Ninguno
**Retorna**: `string` - Recibo formateado con toda la información del pago

## Operaciones CRUD

Las operaciones CRUD para pagos se manejan a través de la clase controladora `TLista`:

### Almacenamiento

```csharp
public static List<Pago> ListaPagos = new List<Pago>();
```

### Create (Crear)

```csharp
// Crear y añadir un pago
TLista.ListaPagos.Add(new Pago(
    1,
    TListaPedido.Lista[0],
    11.50m,
    "Efectivo",
    DateTime.Now,
    true));
```

### Read (Leer)

**Listar todos los pagos:**
```csharp
dataGridView1.DataSource = TLista.ListaPagos.ToList();
```

**Obtener un pago específico:**
```csharp
Pago pago = TLista.ListaPagos[index];
```

### Update (Actualizar)

Los pagos pueden ser modificados directamente a través de sus propiedades:

```csharp
TLista.ListaPagos[0].Monto = 15m;
TLista.ListaPagos[0].MetodoPago = "Tarjeta";
TLista.ListaPagos[0].Pagado = true;
```

### Delete (Eliminar)

```csharp
TLista.ListaPagos.RemoveAt(index);
```

## Formulario Relacionado

### frmPagos

**Ubicación**: `Formularios/frmPagos.cs`

**Componentes UI:**
- **TextBox (Código)**: Campo para ingresar el ID del pago
- **ComboBox (Pedidos)**: Selector para seleccionar el pedido asociado al pago
- **TextBox (Monto)**: Campo para visualizar/ingresar el monto (se auto-completa con el total del pedido seleccionado)
- **ComboBox (Método de Pago)**: Selector para elegir el método de pago
- **DateTimePicker**: Selector para la fecha del pago
- **TextBox (Estado)**: Campo de solo lectura que muestra el estado del pago (True/False)
- **DataGridView**: Tabla que lista todos los pagos registrados
- **Botones**: Procesar, Eliminar, Ver Recibo, Limpiar

**Métodos Principales:**

#### CargarCombos()
```csharp
public void CargarCombos()
{
    comboBox1.DataSource = null;
    comboBox1.DataSource = TListaPedido.Lista;
    comboBox1.DisplayMember = "IdPedido";
}
```
Carga la lista de pedidos disponibles en el ComboBox de pedidos.

#### Listar()
```csharp
public void Listar()
{
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = TLista.ListaPagos.ToList();
}
```
Actualiza el DataGridView con la lista de pagos registrados.

#### CrearObjeto()
```csharp
public Pago CrearObjeto()
{
    int idPago = int.Parse(textBox1.Text);
    Pedido pedido = (Pedido)comboBox1.SelectedItem;
    decimal monto = decimal.Parse(textBox2.Text);
    string metodo = comboBox2.SelectedItem.ToString();
    DateTime fecha = dateTimePicker1.Value;

    return new Pago(
        idPago,
        pedido,
        monto,
        metodo,
        fecha,
        false
    );
}
```
Construye un nuevo objeto Pago con los datos ingresados en el formulario.

#### Validar()
```csharp
public bool Validar()
{
    return !textBox1.Text.Equals("") &&
           !textBox2.Text.Equals("") &&
           comboBox1.SelectedIndex >= 0 &&
           comboBox2.SelectedIndex >= 0;
}
```
Valida que todos los campos obligatorios del formulario estén completos.

#### Limpiar()
```csharp
public void Limpiar()
{
    textBox1.Clear();
    textBox2.Clear();
    textBox3.Clear();
    comboBox1.SelectedIndex = -1;
    comboBox2.SelectedIndex = -1;
}
```
Limpia todos los campos del formulario para permitir el ingreso de un nuevo pago.

**Eventos Principales:**

#### button1_Click - Botón "Procesar Pago"
```csharp
private void button1_Click(object sender, EventArgs e)
{
    try
    {
        if (Validar())
        {
            Pago pago = CrearObjeto();
            pago.ProcesarPago();
            TLista.ListaPagos.Add(pago);
            textBox3.Text = pago.Pagado.ToString();
            Listar();
            MessageBox.Show("Pago procesado");
        }
        else
        {
            MessageBox.Show("Complete todos los campos");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```
Valida, crea, procesa y añade el pago a la lista. Actualiza el estado en la UI.

#### button2_Click - Botón "Eliminar"
```csharp
private void button2_Click(object sender, EventArgs e)
{
    if (dataGridView1.CurrentRow != null)
    {
        int pos = dataGridView1.CurrentRow.Index;
        TLista.ListaPagos.RemoveAt(pos);
        Listar();
    }
}
```
Elimina el pago seleccionado de la lista.

#### button3_Click - Botón "Ver Recibo"
```csharp
private void button3_Click(object sender, EventArgs e)
{
    if (dataGridView1.CurrentRow != null)
    {
        int pos = dataGridView1.CurrentRow.Index;
        Pago pago = TLista.ListaPagos[pos];
        MessageBox.Show(pago.GenerarRecibo(), "Recibo");
    }
}
```
Muestra el recibo del pago seleccionado en un MessageBox.

#### comboBox1_SelectedIndexChanged - Cambio de Pedido
```csharp
private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
{
    if (comboBox1.SelectedItem != null)
    {
        Pedido p = (Pedido)comboBox1.SelectedItem;
        textBox2.Text = p.Total.ToString();
    }
}
```
Cuando se selecciona un pedido, automáticamente rellena el campo de monto con el total del pedido.

#### dataGridView1_CellDoubleClick - Doble clic en fila
```csharp
private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
{
    int pos = e.RowIndex;
    if (pos >= 0)
    {
        Pago pago = TLista.ListaPagos[pos];
        MessageBox.Show(pago.GenerarRecibo(), "Detalle Pago");
    }
}
```
Al hacer doble clic en una fila del DataGridView, muestra los detalles del pago en un recibo.

## Funcionamiento dentro del Sistema

### Integración con el Menú Principal

El formulario de pagos es accesible desde el menú principal (`frmMenu.cs`) a través de la opción "Pagos":

```csharp
private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
{
    frmPagos frm = new frmPagos();
    AbrirFormulario(frm);
}
```

### Carga de Datos Iniciales

Los pagos se cargan en la memoria durante la inicialización del sistema (`frmMenu.CargarDatos`):

```csharp
// PAGOS

TLista.ListaPagos.Add(new Pago(
    1,
    TListaPedido.Lista[0],
    11.50m,
    "Efectivo",
    DateTime.Now,
    true));

TLista.ListaPagos.Add(new Pago(
    2,
    TListaPedido.Lista[1],
    23m,
    "Tarjeta",
    DateTime.Now,
    false));
```

### Relación con Otras Entidades

**Pedido**: Cada pago está asociado con un pedido específico. El pago registra la transacción financiera del total de un pedido.

```csharp
public class Pago
{
    public Pedido Pedido { get => pedido; set => pedido = value; }
    // ...
}
```

### Flujo de Operación

1. **Inicio**: Se carga el menú principal y se inicializa la base de datos en memoria
2. **Selección**: El usuario selecciona "Pagos" del menú principal
3. **Visualización**: Se abre el formulario `frmPagos` mostrando todos los pagos registrados
4. **Selección de Pedido**: El usuario selecciona un pedido del ComboBox (el monto se auto-rellena)
5. **Ingreso de Datos**: Se completan los campos: ID de pago, método de pago y fecha
6. **Procesamiento**: Al hacer clic en "Procesar Pago", se valida, se procesa el pago y se añade a la lista
7. **Visualización de Recibo**: El usuario puede ver el recibo del pago procesado
8. **Gestión**: Puede eliminar pagos o consultar detalles haciendo doble clic en la fila

## Reglas de Negocio

1. **Validación de Monto**: 
   - El monto debe ser mayor a 0 para que el pago se procese exitosamente
   
2. **Asociación con Pedido**: 
   - Todo pago debe estar asociado con un pedido existente
   
3. **Métodos de Pago Aceptados**: 
   - Se pueden registrar diferentes métodos de pago (Efectivo, Tarjeta, etc.)
   
4. **Estado del Pago**: 
   - Un pago se marca como pagado (true) cuando se procesa correctamente
   - Un pago puede tener estado pendiente (false) si la validación falla
   
5. **Fecha de Pago**: 
   - Se registra automáticamente la fecha y hora en que se realiza el pago
   
6. **Generación de Recibos**: 
   - Se pueden generar recibos en cualquier momento con los detalles completos del pago
