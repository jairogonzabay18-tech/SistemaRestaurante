# Entidad Pedido

## 1. Propósito

La entidad **Pedido** representa cada una de las órdenes realizadas por los clientes en el restaurante. Esta clase es fundamental para la gestión de ordenes, permitiendo registrar toda la información relacionada con lo que ordena un cliente, quién toma la orden, en qué mesa, qué platos se piden y el cálculo total con impuestos.

La entidad **Pedido** es utilizada para:
- Registrar las órdenes realizadas por los clientes del restaurante
- Vincular clientes, meseros, mesas y platos en una sola transacción
- Calcular subtotales, impuestos (IVA) y totales de cada orden
- Gestionar el estado de los pedidos (Pendiente, Preparando, Completado, etc.)
- Mantener un registro histórico de todas las ordenes con fecha y hora
- Ser base fundamental para la gestión de pagos relacionados

---

## 2. Ubicación en el Código

**Archivo**: `Entidades/Pedido.cs`  
**Namespace**: `SistemaRestaurante.Entidades`  
**Tipo**: Clase Concreta

---

## 3. Atributos

La entidad **Pedido** posee los siguientes atributos privados:

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| `idPedido` | `int` | Identificador único del pedido (clave primaria) |
| `cliente` | `Cliente` | Referencia al cliente que realiza el pedido |
| `mesero` | `Mesero` | Referencia al mesero que toma el pedido |
| `mesa` | `Mesa` | Referencia a la mesa donde se realiza el pedido |
| `plato` | `Plato` | Referencia al plato que se está pidiendo |
| `cantidad` | `int` | Cantidad de unidades del plato solicitado |
| `subtotal` | `decimal` | Monto antes de impuestos (precio del plato × cantidad) |
| `iva` | `decimal` | Impuesto al Valor Agregado (15% del subtotal) |
| `total` | `decimal` | Monto final a pagar (subtotal + IVA) |
| `estado` | `string` | Estado del pedido (ej: "Pendiente", "Preparando", "Completado") |
| `fechaHora` | `DateTime` | Fecha y hora en que se realizó el pedido |

---

## 4. Constructores

### 4.1 Constructor Vacío
```csharp
public Pedido()
```
- Constructor por defecto sin parámetros
- Inicializa una instancia vacía de la clase
- Utilizado cuando se requiere crear un objeto que será poblado posteriormente

### 4.2 Constructor Parametrizado
```csharp
public Pedido(int idPedido, Cliente cliente, Mesero mesero, Mesa mesa, 
              Plato plato, int cantidad, decimal subtotal, decimal iva, 
              decimal total, string estado, DateTime fechaHora)
```
- Inicializa una instancia con todos los atributos especificados
- **Parámetros:**
  - `idPedido`: Identificador único del pedido
  - `cliente`: Objeto Cliente asociado
  - `mesero`: Objeto Mesero que atiende el pedido
  - `mesa`: Objeto Mesa donde se realiza el pedido
  - `plato`: Objeto Plato que se ordena
  - `cantidad`: Cantidad solicitada del plato
  - `subtotal`: Valor antes de impuestos
  - `iva`: Impuesto calculado
  - `total`: Valor total del pedido
  - `estado`: Estado actual del pedido
  - `fechaHora`: Momento del registro del pedido

---

## 5. Propiedades (Properties)

La clase implementa propiedades con acceso get/set para todos los atributos:

| Propiedad | Tipo | Acceso | Descripción |
|-----------|------|--------|-------------|
| `IdPedido` | `int` | get/set | Acceso a identificador del pedido |
| `Cliente` | `Cliente` | get/set | Acceso al cliente del pedido |
| `Mesero` | `Mesero` | get/set | Acceso al mesero del pedido |
| `Mesa` | `Mesa` | get/set | Acceso a la mesa del pedido |
| `Plato` | `Plato` | get/set | Acceso al plato del pedido |
| `Cantidad` | `int` | get/set | Acceso a la cantidad ordenada |
| `Subtotal` | `decimal` | get/set | Acceso al subtotal |
| `Iva` | `decimal` | get/set | Acceso al IVA |
| `Total` | `decimal` | get/set | Acceso al total |
| `Estado` | `string` | get/set | Acceso al estado del pedido |
| `FechaHora` | `DateTime` | get/set | Acceso a la fecha y hora |

---

## 6. Métodos

### 6.1 CalcularTotal()
```csharp
public decimal CalcularTotal()
```
**Propósito**: Calcula automáticamente el IVA y el total del pedido basado en el subtotal.

**Lógica**:
- Calcula el IVA como el 15% del subtotal: `Iva = Subtotal * 0.15m`
- Calcula el total sumando subtotal e IVA: `Total = Subtotal + Iva`
- Retorna el valor total calculado

**Retorno**: `decimal` - El monto total del pedido

**Ejemplo de uso**:
```csharp
Pedido miPedido = new Pedido(1, cliente, mesero, mesa, plato, 2, 50m, 0m, 0m, "Pendiente", DateTime.Now);
decimal total = miPedido.CalcularTotal(); // Calcula IVA (7.5m) y Total (57.5m)
```

### 6.2 CambiarEstado(string nuevoEstado)
```csharp
public void CambiarEstado(string nuevoEstado)
```
**Propósito**: Modifica el estado actual del pedido a uno nuevo especificado.

**Parámetros**:
- `nuevoEstado` (`string`): El nuevo estado a asignar al pedido

**Descripción**: Actualiza la propiedad `Estado` con el valor proporcionado, permitiendo rastrear el progreso del pedido en la cocina.

**Estados posibles**: 
- "Pendiente" - Pedido registrado pero no iniciado
- "Preparando" - Pedido en proceso de preparación
- "Completado" - Pedido listo para servir

**Ejemplo de uso**:
```csharp
miPedido.CambiarEstado("Preparando");
miPedido.CambiarEstado("Completado");
```

### 6.3 ImprimirPedido()
```csharp
public string ImprimirPedido()
```
**Propósito**: Genera una representación formateada del pedido para impresión o visualización.

**Retorno**: `string` - Texto formateado con toda la información del pedido

**Formato de salida**:
```
PEDIDO
Código Pedido: [IdPedido]
Cliente: [Nombre Completo Cliente]
Mesero: [Nombre Completo Mesero]
Mesa: [Número de Mesa]
Subtotal: $[Subtotal]
IVA: $[Iva]
Total: $[Total]
Estado: [Estado]
```

**Ejemplo de uso**:
```csharp
string comprobante = miPedido.ImprimirPedido();
Console.WriteLine(comprobante);
```

### 6.4 ToString()
```csharp
public override string ToString()
```
**Propósito**: Retorna una representación en texto del pedido.

**Retorno**: `string` - El ID del pedido como cadena de texto

**Uso**: Sobreescribe el método ToString() de la clase Object, permitiendo obtener rápidamente el identificador del pedido cuando se convierte a string.

**Ejemplo de uso**:
```csharp
string id = miPedido.ToString(); // Retorna "1"
MessageBox.Show("Pedido: " + miPedido); // Mostrará "Pedido: 1"
```

---

## 7. Operaciones CRUD

### 7.1 Controlador: TListaPedido

La clase `TListaPedido` en `Controlador/TListaPedido.cs` gestiona todas las operaciones CRUD para la entidad Pedido:

#### CREATE (Crear)
```csharp
public static void Insert(Pedido op)
```
- **Descripción**: Inserta un nuevo pedido en la lista
- **Validación**: Verifica que el objeto no sea null
- **Comportamiento**: Si el objeto es válido, lo añade a `Lista`; si es null, muestra mensaje de error
- **Ejemplo**:
```csharp
Pedido nuevoPedido = new Pedido(1, cliente, mesero, mesa, plato, 2, 50m, 7.50m, 57.50m, "Pendiente", DateTime.Now);
TListaPedido.Insert(nuevoPedido);
```

#### READ (Leer)
```csharp
public static Pedido GetPedido(int pos)
```
- **Descripción**: Obtiene un pedido en una posición específica
- **Validación**: Verifica que la posición sea válida (>= 0 y < Lista.Count)
- **Retorno**: El pedido en la posición indicada, o null si no existe
- **Ejemplo**:
```csharp
Pedido pedido = TListaPedido.GetPedido(0);
if (pedido != null)
{
    MessageBox.Show("Pedido: " + pedido.IdPedido);
}
```

#### UPDATE (Actualizar)
```csharp
public static void Update(int pos, Pedido op)
```
- **Descripción**: Actualiza un pedido existente en la lista
- **Validación**: Verifica que la posición sea válida (>= 0) y que el objeto no sea null
- **Comportamiento**: Reemplaza el pedido en la posición con el nuevo objeto
- **Ejemplo**:
```csharp
Pedido pedidoModificado = new Pedido(1, cliente, mesero, mesa, plato, 3, 75m, 11.25m, 86.25m, "Preparando", DateTime.Now);
TListaPedido.Update(0, pedidoModificado);
```

#### DELETE (Eliminar)
```csharp
public static void Delete(int pos)
```
- **Descripción**: Elimina un pedido de la lista
- **Validación**: Verifica que la posición sea válida (>= 0)
- **Comportamiento**: Remueve el pedido en la posición especificada
- **Ejemplo**:
```csharp
TListaPedido.Delete(0); // Elimina el primer pedido
```

#### SEARCH (Buscar)
```csharp
public static int Buscar(int idPedido)
```
- **Descripción**: Busca un pedido por su identificador
- **Retorno**: La posición (índice) del pedido si existe, o -1 si no se encuentra
- **Ejemplo**:
```csharp
int posicion = TListaPedido.Buscar(1);
if (posicion != -1)
{
    Pedido p = TListaPedido.GetPedido(posicion);
}
```

---

## 8. Formulario Relacionado: frmPedidos

### 8.1 Ubicación
**Archivo**: `Formularios/frmPedidos.cs`  
**Tipo**: Windows Form

### 8.2 Propósito
Proporciona una interfaz gráfica para la gestión completa de pedidos, permitiendo crear, visualizar, modificar y eliminar pedidos de forma intuitiva.

### 8.3 Componentes Principales

#### Campos de Entrada

| Control | Nombre | Tipo | Descripción |
|---------|--------|------|-------------|
| TextBox 1 | textBox1 | TextBox | ID del Pedido |
| TextBox 2 | textBox2 | TextBox | Cantidad de platos |
| TextBox 3 | textBox3 | TextBox (deshabilitado) | Subtotal (calculado automáticamente) |
| TextBox 4 | textBox4 | TextBox (deshabilitado) | IVA (calculado automáticamente) |
| TextBox 5 | textBox5 | TextBox (deshabilitado) | Total (calculado automáticamente) |

#### Combos (Listas Desplegables)

| Control | Nombre | Descripción | Datos |
|---------|--------|-------------|-------|
| ComboBox 1 | comboBox1 | Cliente | TListaCliente.Lista (DisplayMember: "Nombre") |
| ComboBox 2 | comboBox2 | Mesero | TLista.ListaMeseros (DisplayMember: "Nombre") |
| ComboBox 3 | comboBox3 | Mesa | TLista.ListaMesas (DisplayMember: "Numero") |
| ComboBox 4 | comboBox4 | Plato | TListaPlato.Lista (DisplayMember: "Nombre") |
| ComboBox 5 | comboBox5 | Estado | Estados disponibles (se carga en el código) |

#### Otros Controles

| Control | Nombre | Descripción |
|---------|--------|-------------|
| DateTimePicker | dateTimePicker1 | Selecciona la fecha y hora del pedido |
| DataGridView | dataGridView1 | Tabla que muestra todos los pedidos registrados |

#### Botones

| Botón | Función | Evento |
|-------|---------|--------|
| Button 1 | Guardar (Crear) | button1_Click |
| Button 2 | Actualizar (Editar) | button2_Click |
| Button 3 | Eliminar | button3_Click |
| Button 4 | Calcular | button4_Click |
| Button 5 | Limpiar Formulario | button5_Click |

### 8.4 Métodos del Formulario

#### CargarCombos()
```csharp
public void CargarCombos()
```
**Propósito**: Carga las fuentes de datos en todos los ComboBox del formulario.

**Acciones**:
1. Limpia y recarga comboBox1 (Cliente) desde TListaCliente.Lista
2. Limpia y recarga comboBox2 (Mesero) desde TLista.ListaMeseros
3. Limpia y recarga comboBox3 (Mesa) desde TLista.ListaMesas
4. Limpia y recarga comboBox4 (Plato) desde TListaPlato.Lista

#### Listar()
```csharp
public void Listar()
```
**Propósito**: Actualiza la tabla (DataGridView) con todos los pedidos de TListaPedido.Lista.

**Acciones**:
- Limpia la fuente de datos del DataGridView
- Asigna TListaPedido.Lista como nueva fuente
- Convierte a List para compatibilidad

#### Calcular()
```csharp
public void Calcular()
```
**Propósito**: Calcula automáticamente el subtotal, IVA y total basado en el plato y cantidad seleccionados.

**Lógica**:
1. Obtiene el plato seleccionado de comboBox4
2. Obtiene la cantidad de textBox2
3. Calcula: `subtotal = plato.Precio * cantidad`
4. Calcula: `iva = subtotal * 0.15m`
5. Calcula: `total = subtotal + iva`
6. Rellena textBox3, textBox4 y textBox5 con los valores

**Nota**: Los campos de subtotal, IVA y total están deshabilitados (Enabled=false) para que no se editen manualmente.

#### CrearObjeto()
```csharp
public Pedido CrearObjeto()
```
**Propósito**: Recopila todos los datos del formulario y construye un objeto Pedido.

**Acciones**:
1. Extrae el ID del pedido de textBox1
2. Extrae el cliente seleccionado de comboBox1
3. Extrae el mesero seleccionado de comboBox2
4. Extrae la mesa seleccionada de comboBox3
5. Extrae el plato seleccionado de comboBox4
6. Extrae la cantidad de textBox2
7. Extrae subtotal, IVA y total de textBox3, textBox4, textBox5
8. Extrae el estado de comboBox5
9. Extrae la fecha/hora de dateTimePicker1
10. Retorna un nuevo objeto Pedido con todos estos datos

**Retorno**: Un objeto `Pedido` completamente inicializado

#### Validar()
```csharp
public bool Validar()
```
**Propósito**: Valida que todos los campos requeridos estén completos.

**Validaciones**:
- textBox1 no esté vacío (ID)
- textBox2 no esté vacío (Cantidad)
- textBox3 no esté vacío (Subtotal)
- textBox4 no esté vacío (IVA)
- textBox5 no esté vacío (Total)
- comboBox1 tenga un item seleccionado (Cliente)
- comboBox2 tenga un item seleccionado (Mesero)
- comboBox3 tenga un item seleccionado (Mesa)
- comboBox4 tenga un item seleccionado (Plato)
- comboBox5 tenga un item seleccionado (Estado)

**Retorno**: `true` si todas las validaciones pasan, `false` en caso contrario

#### Limpiar()
```csharp
public void Limpiar()
```
**Propósito**: Limpia todos los campos del formulario para prepararlo para un nuevo registro.

**Acciones**:
- Borra contenido de todos los TextBox (1-5)
- Reinicia índice de todos los ComboBox a -1 (sin selección)

### 8.5 Eventos del Formulario

#### frmPedidos_Load
```csharp
private void frmPedidos_Load(object sender, EventArgs e)
```
- Se ejecuta cuando se carga el formulario
- Llama a `CargarCombos()` para inicializar los ComboBox
- Llama a `Listar()` para mostrar todos los pedidos

#### button1_Click - Guardar (Crear)
```csharp
private void button1_Click(object sender, EventArgs e)
```
**Flujo de operación**:
1. Valida que todos los campos estén completos
2. Si la validación es exitosa:
   - Crea un objeto Pedido llamando a `CrearObjeto()`
   - Reduce el stock del plato: `p.Plato.DisminuirStock(p.Cantidad)`
   - Inserta el pedido en la lista: `TListaPedido.Insert(p)`
   - Actualiza la tabla: `Listar()`
   - Limpia los campos: `Limpiar()`
3. Si la validación falla: Muestra mensaje "Complete todos los campos"
4. Manejo de excepciones: Muestra el mensaje de error si ocurre

#### button2_Click - Actualizar (Editar)
```csharp
private void button2_Click(object sender, EventArgs e)
```
**Flujo de operación**:
1. Verifica que haya una fila seleccionada en el DataGridView
2. Si hay selección:
   - Obtiene la posición del elemento: `int pos = dataGridView1.CurrentRow.Index`
   - Crea un objeto Pedido con los datos del formulario: `CrearObjeto()`
   - Actualiza el pedido: `TListaPedido.Update(pos, CrearObjeto())`
   - Actualiza la tabla: `Listar()`
   - Limpia los campos: `Limpiar()`
3. Manejo de excepciones: Muestra el mensaje de error si ocurre

#### button3_Click - Eliminar
```csharp
private void button3_Click(object sender, EventArgs e)
```
**Flujo de operación**:
1. Verifica que haya una fila seleccionada en el DataGridView
2. Si hay selección:
   - Muestra un cuadro de diálogo de confirmación: "¿Desea eliminar el pedido?"
   - Si el usuario selecciona "Sí":
     - Obtiene la posición: `int pos = dataGridView1.CurrentRow.Index`
     - Elimina el pedido: `TListaPedido.Delete(pos)`
     - Actualiza la tabla: `Listar()`
     - Limpia los campos: `Limpiar()`
3. Manejo de excepciones: Muestra el mensaje de error si ocurre

#### button4_Click - Calcular
```csharp
private void button4_Click(object sender, EventArgs e)
```
- Llama al método `Calcular()` para computar subtotal, IVA y total
- Se ejecuta cuando el usuario cambia la cantidad o el plato

#### button5_Click - Limpiar Formulario
```csharp
private void button5_Click(object sender, EventArgs e)
```
- Llama al método `Limpiar()` para resetear todos los campos

#### dataGridView1_CellClick - Seleccionar Fila
```csharp
private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
```
**Propósito**: Cuando el usuario hace clic en una fila de la tabla, carga todos los datos de ese pedido en el formulario para edición.

**Flujo de operación**:
1. Obtiene el índice de la fila seleccionada: `int pos = e.RowIndex`
2. Verifica que la posición sea válida (>= 0)
3. Obtiene el pedido: `Pedido p = TListaPedido.GetPedido(pos)`
4. Rellena todos los campos del formulario con los datos del pedido:
   - textBox1 ← IdPedido
   - comboBox1 ← Cliente
   - comboBox2 ← Mesero
   - comboBox3 ← Mesa
   - comboBox4 ← Plato
   - textBox2 ← Cantidad
   - textBox3 ← Subtotal
   - textBox4 ← IVA
   - textBox5 ← Total
   - comboBox5 ← Estado
   - dateTimePicker1 ← FechaHora

---

## 9. Relaciones con Otras Entidades

### 9.1 Relación con Cliente
```csharp
private Cliente cliente;
public Cliente Cliente { get => cliente; set => cliente = value; }
```
- Cada pedido está asociado con exactamente un cliente
- Se utiliza para identificar quién realiza el pedido
- En el formulario se selecciona de `TListaCliente.Lista`

### 9.2 Relación con Mesero
```csharp
private Mesero mesero;
public Mesero Mesero { get => mesero; set => mesero = value; }
```
- Cada pedido es atendido por un mesero específico
- Se utiliza para rastrear quién toma la orden
- En el formulario se selecciona de `TLista.ListaMeseros`

### 9.3 Relación con Mesa
```csharp
private Mesa mesa;
public Mesa Mesa { get => mesa; set => mesa = value; }
```
- Cada pedido se realiza en una mesa específica del restaurante
- Se utiliza para ubicar dónde se sirve el pedido
- En el formulario se selecciona de `TLista.ListaMesas`

### 9.4 Relación con Plato
```csharp
private Plato plato;
public Plato Plato { get => plato; set => plato = value; }
```
- Cada pedido contiene un plato específico del menú
- El precio del pedido se calcula basado en `plato.Precio * cantidad`
- Cuando se crea un pedido, el stock del plato se reduce automáticamente
- Ejemplo en frmPedidos.cs: `p.Plato.DisminuirStock(p.Cantidad)`

### 9.5 Relación con Pago
```csharp
// En Entidades/Pago.cs
private Pedido pedido;
public Pedido Pedido { get => pedido; set => pedido = value; }
```
- Un pedido puede tener un pago asociado
- La entidad Pago referencia a Pedido para registrar el pago de una orden
- El monto del pago generalmente corresponde al total del pedido

---

## 10. Flujo de Funcionamiento del Sistema

### 10.1 Proceso de Creación de un Pedido

```
1. Usuario abre frmPedidos
   ↓
2. Se cargan los combos (clientes, meseros, mesas, platos)
   ↓
3. Usuario selecciona datos: cliente, mesero, mesa, plato, cantidad
   ↓
4. Usuario hace clic en "Calcular"
   ↓
5. Sistema calcula: subtotal = plato.Precio × cantidad
                    iva = subtotal × 0.15
                    total = subtotal + iva
   ↓
6. Usuario hace clic en "Guardar"
   ↓
7. Sistema valida que todos los campos estén completos
   ↓
8. Si validación es OK:
   - Crea objeto Pedido con todos los datos
   - Reduce stock del plato: plato.DisminuirStock(cantidad)
   - Inserta en TListaPedido
   - Actualiza la tabla del formulario
   - Limpia los campos
   ↓
9. Pedido queda registrado en el sistema
```

### 10.2 Proceso de Modificación de un Pedido

```
1. Usuario hace clic en una fila de la tabla
   ↓
2. Sistema carga todos los datos del pedido en el formulario
   ↓
3. Usuario modifica los datos necesarios
   ↓
4. Usuario hace clic en "Actualizar"
   ↓
5. Sistema reemplaza el pedido en la lista
   ↓
6. Se actualiza la tabla del formulario
```

### 10.3 Proceso de Eliminación de un Pedido

```
1. Usuario selecciona una fila de la tabla
   ↓
2. Usuario hace clic en "Eliminar"
   ↓
3. Sistema muestra confirmación: "¿Desea eliminar el pedido?"
   ↓
4. Si usuario selecciona "Sí":
   - Elimina el pedido de TListaPedido
   - Actualiza la tabla
   ↓
5. Pedido es removido del sistema
```

### 10.4 Integración con Pagos

```
Pedido Completado → Se vincula con Pago
   ↓
Pago registra el monto total del Pedido
   ↓
El sistema puede generar reportes de pedidos y pagos
```

---

## 11. Ejemplos de Uso

### Ejemplo 1: Crear un Pedido Programáticamente
```csharp
// Crear objetos relacionados
Cliente cliente = new Cliente(1, "Juan", "Pérez", ...);
Mesero mesero = new Mesero(1, "Carlos", "López", ...);
Mesa mesa = new Mesa(1, 4, true);
Plato plato = new Plato(1, "Encebollado", "Ceviche ecuatoriano", 8.50m, "Plato Fuerte", true, 50);

// Crear el pedido
Pedido pedido = new Pedido(
    1,                      // ID
    cliente,                // Cliente
    mesero,                 // Mesero
    mesa,                   // Mesa
    plato,                  // Plato
    2,                      // Cantidad
    17.00m,                 // Subtotal (8.50 × 2)
    0m,                     // IVA (será calculado)
    0m,                     // Total (será calculado)
    "Pendiente",            // Estado
    DateTime.Now            // Fecha/Hora
);

// Calcular totales
pedido.CalcularTotal();  // Calcula IVA: 2.55, Total: 19.55

// Insertar en la lista
TListaPedido.Insert(pedido);

// Cambiar estado
pedido.CambiarEstado("Preparando");

// Imprimir
Console.WriteLine(pedido.ImprimirPedido());
```

### Ejemplo 2: Buscar y Modificar un Pedido
```csharp
// Buscar un pedido por ID
int posicion = TListaPedido.Buscar(1);

if (posicion != -1)
{
    // Obtener el pedido
    Pedido p = TListaPedido.GetPedido(posicion);
    
    // Modificar el estado
    p.CambiarEstado("Completado");
    
    // Actualizar en la lista
    TListaPedido.Update(posicion, p);
}
```

### Ejemplo 3: Listar Todos los Pedidos
```csharp
foreach (Pedido p in TListaPedido.Lista)
{
    MessageBox.Show($"Pedido: {p.IdPedido}, Cliente: {p.Cliente.Nombre}, Total: ${p.Total}");
}
```

---

## 12. Validaciones y Restricciones

- **ID Pedido**: Debe ser un número entero positivo
- **Cantidad**: Debe ser mayor a 0 y no puede exceder el stock disponible
- **Subtotal**: Se calcula automáticamente (no se edita manualmente en el formulario)
- **IVA**: Se calcula automáticamente como 15% del subtotal
- **Total**: Se calcula automáticamente como subtotal + IVA
- **Estado**: Debe ser uno de los estados predefinidos
- **Cliente, Mesero, Mesa, Plato**: Deben ser seleccionados de las listas disponibles

---

## 13. Estructura de Archivos Relacionados

```
SistemaRestaurante/
├── Entidades/
│   ├── Pedido.cs                 # Definición de la entidad
│   ├── Cliente.cs                # Entidad relacionada
│   ├── Mesero.cs                 # Entidad relacionada
│   ├── Mesa.cs                   # Entidad relacionada
│   ├── Plato.cs                  # Entidad relacionada
│   └── Pago.cs                   # Entidad relacionada
├── Controlador/
│   └── TListaPedido.cs           # Gestión CRUD de pedidos
├── Formularios/
│   ├── frmPedidos.cs             # Formulario principal
│   └── frmPedidos.Designer.cs    # Diseño del formulario
└── ssd/
    └── pedido.md                 # Documentación (este archivo)
```

---

## Conclusión

La entidad **Pedido** es el corazón del sistema de gestión de pedidos del restaurante. Integra información de clientes, meseros, mesas y platos en una transacción única, calculando automáticamente los montos e impuestos. Su flexible sistema de estados permite rastrear el progreso de cada orden desde su creación hasta su finalización y pago.
