# Entidad Pago

## 1. Propósito

La entidad **Pago** gestiona el procesamiento y registro de pagos asociados a pedidos dentro del sistema de restaurante. Su función principal es:

- Registrar información de pagos realizados por clientes
- Procesar transacciones monetarias
- Generar recibos de pago
- Mantener el estado de pagos (pagado o pendiente)
- Vincular pagos con pedidos específicos
- Registrar el método de pago utilizado

La entidad actúa como intermediaria entre los pedidos completados y la gestión financiera del restaurante.

---

## 2. Atributos

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| `idPago` | `int` | Identificador único del pago (clave primaria) |
| `pedido` | `Pedido` | Referencia al pedido asociado al pago |
| `monto` | `decimal` | Cantidad de dinero a pagar (en formato monetario) |
| `metodoPago` | `string` | Método utilizado para realizar el pago (ej: "Efectivo", "Tarjeta") |
| `fechaPago` | `DateTime` | Fecha y hora en que se realizó el pago |
| `pagado` | `bool` | Indicador del estado del pago (true = pagado, false = pendiente) |

---

## 3. Métodos

### 3.1 Constructores

#### Constructor Vacío
```csharp
public Pago()
```
- Constructor por defecto sin parámetros
- Inicializa una instancia vacía de la clase

#### Constructor Parametrizado
```csharp
public Pago(int idPago, Pedido pedido, decimal monto, 
            string metodoPago, DateTime fechaPago, bool pagado)
```
- Inicializa una instancia con todos los atributos especificados
- **Parámetros:**
  - `idPago`: Identificador del pago
  - `pedido`: Pedido asociado
  - `monto`: Cantidad a pagar
  - `metodoPago`: Método de pago
  - `fechaPago`: Fecha del pago
  - `pagado`: Estado del pago

### 3.2 Propiedades (Getters y Setters)

```csharp
public int IdPago { get => idPago; set => idPago = value; }
public Pedido Pedido { get => pedido; set => pedido = value; }
public decimal Monto { get => monto; set => monto = value; }
public string MetodoPago { get => metodoPago; set => metodoPago = value; }
public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
public bool Pagado { get => pagado; set => pagado = value; }
```

Todas las propiedades son de acceso público y permiten lectura y escritura de los atributos privados.

### 3.3 Métodos de Negocio

#### ProcesarPago()
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
- **Propósito:** Procesa el pago validando que el monto sea válido
- **Lógica:**
  - Valida que el monto sea mayor a 0
  - Si es válido: marca el pago como completado (`Pagado = true`) y retorna `true`
  - Si no es válido: retorna `false`
- **Retorno:** `bool` - Indica si el pago fue procesado exitosamente

#### GenerarRecibo()
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
- **Propósito:** Genera un recibo de pago en formato de texto
- **Contenido del recibo:**
  - Código del pago
  - ID del pedido asociado
  - Monto pagado (con símbolo $)
  - Método de pago utilizado
  - Fecha del pago
  - Estado del pago (true/false)
- **Retorno:** `string` - Recibo formateado con saltos de línea

---

## 4. Operaciones CRUD

| Operación | Método | Ubicación | Descripción |
|-----------|--------|-----------|-------------|
| **Create (Crear)** | `CrearObjeto()` | `frmPagos.cs` | Instancia un nuevo objeto Pago con datos del formulario |
| **Read (Leer)** | `Listar()` | `frmPagos.cs` | Carga la lista de pagos en el DataGridView |
| **Update (Actualizar)** | No implementado | - | El sistema actual no soporta actualización de pagos |
| **Delete (Eliminar)** | `RemoveAt(pos)` | `frmPagos.cs` | Elimina un pago de la lista por su índice |

### Detalles de Operaciones

#### Create
```csharp
public Pago CrearObjeto()
{
    int idPago = int.Parse(textBox1.Text);
    Pedido pedido = (Pedido)comboBox1.SelectedItem;
    decimal monto = decimal.Parse(textBox2.Text);
    string metodo = comboBox2.SelectedItem.ToString();
    DateTime fecha = dateTimePicker1.Value;
    
    return new Pago(idPago, pedido, monto, metodo, fecha, false);
}
```

#### Read
```csharp
public void Listar()
{
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = TLista.ListaPagos.ToList();
}
```

#### Delete
```csharp
int pos = dataGridView1.CurrentRow.Index;
TLista.ListaPagos.RemoveAt(pos);
Listar(); // Actualiza la vista
```

---

## 5. Formularios Relacionados

### 5.1 frmPagos (Formulario Principal de Pagos)

**Ubicación:** `Formularios/frmPagos.cs`

#### Componentes de Interfaz

| Componente | Tipo | Función |
|-----------|------|---------|
| `textBox1` | TextBox | Ingreso del código de pago (ID) |
| `comboBox1` | ComboBox | Selección del pedido asociado |
| `textBox2` | TextBox | Mostrar el monto del pedido (auto-completado) |
| `comboBox2` | ComboBox | Selección del método de pago |
| `dateTimePicker1` | DateTimePicker | Selección de la fecha del pago |
| `textBox3` | TextBox | Mostrar estado del pago (solo lectura) |
| `dataGridView1` | DataGridView | Mostrar lista de pagos registrados |
| `button1` | Button | Procesar nuevo pago |
| `button2` | Button | Eliminar pago seleccionado |
| `button3` | Button | Ver recibo del pago |
| `button4` | Button | Limpiar formulario |

#### Métodos Principales

| Método | Descripción |
|--------|-------------|
| `CargarCombos()` | Carga la lista de pedidos en el comboBox1 |
| `Listar()` | Actualiza el DataGridView con la lista de pagos |
| `CrearObjeto()` | Instancia un nuevo Pago con datos del formulario |
| `Validar()` | Verifica que todos los campos obligatorios estén completos |
| `Limpiar()` | Limpia todos los campos del formulario |

#### Eventos Principales

| Evento | Funcionalidad |
|--------|---------------|
| `frmPagos_Load` | Carga combos y lista de pagos al abrir el formulario |
| `button1_Click` | Crea y procesa un nuevo pago |
| `button2_Click` | Elimina el pago seleccionado |
| `button3_Click` | Genera y muestra el recibo en un MessageBox |
| `button4_Click` | Limpia los campos del formulario |
| `comboBox1_SelectedIndexChanged` | Auto-completa el monto cuando se selecciona un pedido |
| `dataGridView1_CellDoubleClick` | Muestra el recibo al hacer doble clic en una fila |

---

## 6. Funcionamiento Dentro del Sistema

### 6.1 Flujo de Procesamiento de Pago

```
1. Usuario selecciona "Pagos" del menú principal
   ↓
2. Se abre frmPagos y carga la lista de pedidos disponibles
   ↓
3. Usuario ingresa datos del pago:
   - ID del pago
   - Selecciona el pedido (auto-completa el monto)
   - Selecciona método de pago
   - Confirma la fecha
   ↓
4. Usuario hace clic en "Procesar Pago"
   ↓
5. Sistema valida los datos
   ↓
6. Se crea el objeto Pago con estado pagado=false
   ↓
7. Se ejecuta ProcesarPago():
   - Valida que monto > 0
   - Marca el pago como completado (pagado=true)
   ↓
8. Se agrega el pago a TLista.ListaPagos
   ↓
9. Se actualiza el DataGridView
   ↓
10. Se muestra confirmación al usuario
```

### 6.2 Integración con Otras Entidades

#### Relación con Pedido
- Cada pago está **vinculado a un Pedido** específico
- El monto del pago se obtiene del total del pedido (`p.Total`)
- No puede crearse un pago sin un pedido asociado

#### Relación con el Controlador
- Los pagos se almacenan en `TLista.ListaPagos` (colección estática)
- Se accede mediante la clase controladora `TLista`

### 6.3 Almacenamiento

**Tipo:** Colección en memoria (`List<Pago>`)

```csharp
public static List<Pago> ListaPagos = new List<Pago>();
```

- Los datos se mantienen durante la sesión de la aplicación
- No persisten en base de datos (almacenamiento temporal)

### 6.4 Datos de Ejemplo

El sistema inicializa con dos pagos de prueba en `frmMenu.cs`:

```csharp
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

---

## 7. Validaciones y Restricciones

### Validaciones en el Formulario

```csharp
public bool Validar()
{
    return !textBox1.Text.Equals("") &&      // ID requerido
           !textBox2.Text.Equals("") &&      // Monto requerido
           comboBox1.SelectedIndex >= 0 &&   // Pedido requerido
           comboBox2.SelectedIndex >= 0;     // Método de pago requerido
}
```

### Validaciones en ProcesarPago()
- **Monto debe ser mayor a 0:** Si `Monto <= 0`, el pago no se procesa
- **Cambio de estado automático:** Si es válido, `Pagado` se establece en `true`

---

## 8. Características Destacadas

1. **Auto-llenado de Monto:** Al seleccionar un pedido, el monto se completa automáticamente con el total del pedido

2. **Generación de Recibos:** Método `GenerarRecibo()` formatea la información para presentación

3. **Listado Dinámico:** El DataGridView se actualiza automáticamente después de operaciones CRUD

4. **Doble Clic para Detalles:** Hacer doble clic en un pago muestra su recibo

5. **Métodos de Pago Flexibles:** Soporta diferentes métodos (Efectivo, Tarjeta, etc.)

6. **Estado de Pago Visible:** El campo `textBox3` muestra si el pago fue procesado exitosamente

---

## 9. Limitaciones Actuales

- ❌ No hay persistencia en base de datos
- ❌ No hay opción de editar pagos después de crearlos
- ❌ No hay validación de duplicados de ID
- ❌ El monto debe ser ingresado manualmente o se auto-completa desde el pedido
- ❌ No hay historial de cambios de estado

---

## 10. Referencias en el Código

- **Entidad:** `Entidades/Pago.cs`
- **Formulario:** `Formularios/frmPagos.cs`
- **Controlador:** `Controlador/TLista.cs` (almacenamiento)
- **Menú Principal:** `Formularios/frmMenu.cs` (acceso a frmPagos)
