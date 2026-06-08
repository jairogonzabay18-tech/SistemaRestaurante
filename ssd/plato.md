# Entidad Plato

## 1. Propósito

La entidad **Plato** representa cada uno de los platos (comidas, bebidas, etc.) que ofrece el restaurante. Esta clase es fundamental para la gestión del menú del restaurante y está directamente relacionada con los pedidos que realizan los clientes.

La entidad **Plato** es utilizada para:
- Definir y almacenar información de los platos disponibles en el restaurante
- Controlar el inventario y disponibilidad de platos
- Mantener información de precios, categorías y descripciones
- Gestionar el stock de cada plato
- Ser parte integral de los pedidos realizados por los clientes
- Calcular el costo total de los pedidos basado en el precio del plato

---

## 2. Ubicación en el Código

**Archivo**: `Entidades/Plato.cs`  
**Namespace**: `SistemaRestaurante.Entidades`  
**Tipo**: Clase Concreta

---

## 3. Atributos

La entidad **Plato** posee los siguientes atributos privados:

| Atributo | Tipo | Descripción |
|----------|------|-------------|
| `id` | `int` | Identificador único del plato (clave primaria) |
| `nombre` | `string` | Nombre del plato (ej: "Arroz con Pollo", "Encebollado") |
| `descripcion` | `string` | Descripción detallada del plato (ej: "Arroz acompañado de pollo") |
| `precio` | `decimal` | Precio unitario del plato en formato monetario |
| `categoria` | `string` | Categoría a la que pertenece (ej: "Plato Fuerte", "Sopa", "Bebida") |
| `disponible` | `bool` | Indicador de disponibilidad del plato (true = disponible, false = no disponible) |
| `stock` | `int` | Cantidad disponible del plato en inventario |

---

## 4. Propiedades (Properties)

Se implementan propiedades públicas con getters y setters para acceder a los atributos privados:

```csharp
public int Id { get => id; set => id = value; }
public string Nombre { get => nombre; set => nombre = value; }
public string Descripcion { get => descripcion; set => descripcion = value; }
public decimal Precio { get => precio; set => precio = value; }
public string Categoria { get => categoria; set => categoria = value; }
public bool Disponible { get => disponible; set => disponible = value; }
public int Stock { get => stock; set => stock = value; }
```

Estas propiedades permiten acceso y modificación controlada de los atributos de la clase.

---

## 5. Constructores

### 5.1 Constructor Vacío

```csharp
public Plato()
{
}
```

Constructor por defecto que inicializa una instancia vacía sin asignar valores a los atributos. Se utiliza cuando se requiere crear un objeto y asignar sus valores posteriormente.

### 5.2 Constructor Parametrizado

```csharp
public Plato(int id, string nombre, string descripcion,
             decimal precio, string categoria,
             bool disponible, int stock)
{
    this.id = id;
    this.nombre = nombre;
    this.descripcion = descripcion;
    this.precio = precio;
    this.categoria = categoria;
    this.disponible = disponible;
    this.stock = stock;
}
```

Inicializa todos los atributos del plato con los parámetros proporcionados. Este constructor es utilizado para crear nuevos platos directamente con todos sus datos.

**Ejemplo de uso** (en `frmMenu.CargarDatos()`):
```csharp
TListaPlato.Insert(new Plato(1, "Arroz con Pollo", "Arroz acompañado de pollo", 4.50m, "Plato Fuerte", true, 20));
TListaPlato.Insert(new Plato(2, "Encebollado", "Encebollado tradicional", 3.75m, "Sopa", true, 15));
TListaPlato.Insert(new Plato(3, "Jugo de Mora", "Bebida natural", 1.50m, "Bebida", true, 30));
```

---

## 6. Métodos

### 6.1 ObtenerPrecio()

```csharp
public decimal ObtenerPrecio()
{
    return Precio;
}
```

**Descripción**: Retorna el precio del plato.  
**Retorna**: `decimal` - El precio unitario del plato  
**Uso**: Se utiliza para obtener el precio de un plato al momento de crear un pedido.

---

### 6.2 CambiarDisponibilidad()

```csharp
public void CambiarDisponibilidad()
{
    Disponible = !Disponible;
}
```

**Descripción**: Cambia el estado de disponibilidad del plato (alterna entre disponible y no disponible).  
**Comportamiento**: Invierte el valor booleano de `Disponible` (si es `true` lo convierte en `false` y viceversa).  
**Uso**: Se utiliza para cambiar rápidamente si un plato está disponible o no en el restaurante.

---

### 6.3 DisminuirStock(int cantidad)

```csharp
public void DisminuirStock(int cantidad)
{
    if (Stock >= cantidad)
    {
        Stock -= cantidad;
    }
}
```

**Descripción**: Reduce el stock del plato en la cantidad especificada.  
**Parámetro**: 
- `cantidad` (`int`) - La cantidad a descontar del stock

**Lógica**: 
- Verifica si hay suficiente stock disponible
- Si `Stock >= cantidad`, reduce el stock en la cantidad especificada
- Si no hay suficiente stock, no realiza ninguna acción

**Uso**: Se utiliza cuando se realiza un pedido, para descontar automáticamente la cantidad de platos del inventario. Por ejemplo, en `frmPedidos.cs`:

```csharp
private void button1_Click(object sender, EventArgs e)
{
    try
    {
        if (Validar())
        {
            Pedido p = CrearObjeto();
            p.Plato.DisminuirStock(p.Cantidad);  // Reduce el stock
            TListaPedido.Insert(p);
            Listar();
            Limpiar();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

---

### 6.4 ImprimirPlato()

```csharp
public string ImprimirPlato()
{
    return "PLATO\n" +
           "Nombre: " + Nombre + "\n" +
           "Descripción: " + Descripcion + "\n" +
           "Categoría: " + Categoria + "\n" +
           "Precio: $" + Precio + "\n" +
           "Stock: " + Stock + "\n" +
           "Disponible: " + Disponible;
}
```

**Descripción**: Genera una representación textual completa y formateada del plato.  
**Retorna**: `string` - Cadena de texto con toda la información del plato  
**Uso**: Se utiliza para mostrar información detallada del plato en mensajes o reportes.

**Ejemplo de salida**:
```
PLATO
Nombre: Arroz con Pollo
Descripción: Arroz acompañado de pollo
Categoría: Plato Fuerte
Precio: $4.50
Stock: 20
Disponible: True
```

---

### 6.5 ToString()

```csharp
public override string ToString()
{
    return Nombre;
}
```

**Descripción**: Sobrescribe el método `ToString()` de la clase `Object`.  
**Retorna**: `string` - El nombre del plato  
**Uso**: Se utiliza automáticamente cuando un objeto `Plato` se convierte a string, particularmente en controles de interfaz gráfica como ComboBox o DataGridView. Muestra solo el nombre del plato de forma simplificada.

**Ejemplo**: En `frmPedidos.cs`, cuando se carga un ComboBox con platos, se muestra automáticamente el nombre gracias a este método.

---

## 7. Operaciones CRUD

Las operaciones CRUD (Create, Read, Update, Delete) para la entidad **Plato** se manejan a través de la clase controladora `TListaPlato`.

### 7.1 Clase Controladora: TListaPlato

**Ubicación**: `Controlador/TListaPlato.cs`

```csharp
public class TListaPlato
{
    public static List<Plato> Lista = new List<Plato>();
    
    // Métodos CRUD...
}
```

---

### 7.2 CREATE - Insertar Plato

**Método**: `Insert(Plato op)`

```csharp
public static void Insert(Plato op)
{
    if (op != null)
        Lista.Add(op);
    else
        MessageBox.Show("Objeto null");
}
```

**Descripción**: Agrega un nuevo plato a la lista.  
**Parámetro**: `op` - Objeto de tipo `Plato` a insertar  
**Validación**: Verifica que el objeto no sea nulo antes de agregarlo  
**Ejemplo de uso**:

```csharp
Plato nuevoPlato = new Plato(4, "Ceviche", "Ceviche tradicional", 5.50m, "Plato Fuerte", true, 25);
TListaPlato.Insert(nuevoPlato);
```

---

### 7.3 READ - Obtener Plato

**Método**: `GetPlato(int pos)`

```csharp
public static Plato GetPlato(int pos)
{
    if (pos >= 0 && pos < Lista.Count)
        return Lista[pos];
    else
        return null;
}
```

**Descripción**: Obtiene un plato de la lista por su posición.  
**Parámetro**: `pos` - Índice del plato en la lista  
**Retorna**: Objeto `Plato` o `null` si la posición no es válida  
**Ejemplo de uso**:

```csharp
Plato plato = TListaPlato.GetPlato(0);
if (plato != null)
{
    MessageBox.Show(plato.ImprimirPlato());
}
```

**Método**: `Buscar(int id)`

```csharp
public static int Buscar(int id)
{
    for (int i = 0; i < Lista.Count; i++)
    {
        if (Lista[i].Id == id)
            return i;
    }
    return -1;
}
```

**Descripción**: Busca la posición de un plato por su identificador (ID).  
**Parámetro**: `id` - Identificador único del plato  
**Retorna**: Posición (índice) del plato en la lista, o `-1` si no se encuentra  
**Ejemplo de uso**:

```csharp
int posicion = TListaPlato.Buscar(2);
if (posicion != -1)
{
    Plato plato = TListaPlato.GetPlato(posicion);
}
```

---

### 7.4 UPDATE - Actualizar Plato

**Método**: `Update(int pos, Plato op)`

```csharp
public static void Update(int pos, Plato op)
{
    if (pos >= 0 && op != null)
        Lista[pos] = op;
    else
        MessageBox.Show("Posición negativa o objeto null");
}
```

**Descripción**: Actualiza un plato existente en la lista.  
**Parámetros**:
- `pos` - Posición del plato a actualizar
- `op` - Nuevo objeto `Plato` con los datos actualizados

**Validación**: Verifica que la posición sea válida y que el objeto no sea nulo  
**Ejemplo de uso** (en `frmPlatos.cs`):

```csharp
private void button2_Click(object sender, EventArgs e)
{
    try
    {
        if (dataGridView1.CurrentRow != null)
        {
            int pos = dataGridView1.CurrentRow.Index;
            TListaPlato.Update(pos, CrearObjeto());
            Listar();
            Limpiar();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

---

### 7.5 DELETE - Eliminar Plato

**Método**: `Delete(int pos)`

```csharp
public static void Delete(int pos)
{
    if (pos >= 0)
        Lista.RemoveAt(pos);
    else
        MessageBox.Show("Posición negativa");
}
```

**Descripción**: Elimina un plato de la lista.  
**Parámetro**: `pos` - Posición del plato a eliminar  
**Validación**: Verifica que la posición sea válida  
**Ejemplo de uso** (en `frmPlatos.cs`):

```csharp
private void button3_Click(object sender, EventArgs e)
{
    try
    {
        if (dataGridView1.CurrentRow != null)
        {
            DialogResult r = MessageBox.Show(
                "¿Desea eliminar el plato?",
                "Eliminar",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                int pos = dataGridView1.CurrentRow.Index;
                TListaPlato.Delete(pos);
                Listar();
                Limpiar();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

---

## 8. Formulario Relacionado: frmPlatos

**Ubicación**: `Formularios/frmPlatos.cs`  
**Propósito**: Formulario para gestionar (crear, actualizar, eliminar y visualizar) los platos disponibles en el restaurante.

### 8.1 Componentes del Formulario

| Componente | Tipo | Descripción |
|-----------|------|-------------|
| `textBox1` | TextBox | Campo para ingresar el ID del plato |
| `textBox2` | TextBox | Campo para ingresar el nombre del plato |
| `textBox3` | TextBox | Campo para ingresar la descripción del plato |
| `textBox4` | TextBox | Campo para ingresar el precio del plato |
| `textBox5` | TextBox | Campo para ingresar el stock del plato |
| `comboBox1` | ComboBox | Selector de categoría (Plato Fuerte, Sopa, Bebida, etc.) |
| `comboBox2` | ComboBox | Selector de disponibilidad (Disponible/No disponible) |
| `dataGridView1` | DataGridView | Tabla que muestra la lista de todos los platos |
| `button1` | Button | Botón para agregar (INSERT) un nuevo plato |
| `button2` | Button | Botón para actualizar (UPDATE) el plato seleccionado |
| `button3` | Button | Botón para eliminar (DELETE) el plato seleccionado |
| `button4` | Button | Botón para limpiar (CLEAR) los campos del formulario |

### 8.2 Métodos Principales

#### Listar()

```csharp
public void Listar()
{
    dataGridView1.DataSource = null;
    dataGridView1.DataSource = TListaPlato.Lista.ToList();
}
```

**Descripción**: Carga y actualiza la lista de todos los platos en el DataGridView.  
**Uso**: Se llama cada vez que se realiza una operación CRUD para refrescar la visualización.

---

#### CrearObjeto()

```csharp
public Plato CrearObjeto()
{
    int id = int.Parse(textBox1.Text);
    string nombre = textBox2.Text;
    string descripcion = textBox3.Text;
    decimal precio = decimal.Parse(textBox4.Text);
    string categoria = comboBox1.SelectedItem.ToString();
    bool disponible = bool.Parse(comboBox2.SelectedItem.ToString());
    int stock = int.Parse(textBox5.Text);

    return new Plato(
        id,
        nombre,
        descripcion,
        precio,
        categoria,
        disponible,
        stock
    );
}
```

**Descripción**: Lee los valores de los controles del formulario y crea un nuevo objeto `Plato`.  
**Retorna**: Nuevo objeto `Plato` con los datos ingresados  
**Uso**: Se utiliza en las operaciones INSERT y UPDATE.

---

#### Validar()

```csharp
public bool Validar()
{
    return !textBox1.Text.Equals("") &&
           !textBox2.Text.Equals("") &&
           !textBox3.Text.Equals("") &&
           !textBox4.Text.Equals("") &&
           !textBox5.Text.Equals("") &&
           comboBox1.SelectedIndex >= 0 &&
           comboBox2.SelectedIndex >= 0;
}
```

**Descripción**: Verifica que todos los campos obligatorios estén completos.  
**Retorna**: `true` si la validación es exitosa, `false` en caso contrario  
**Validaciones**:
- Todos los TextBox deben tener contenido
- ComboBox1 (Categoría) debe tener una selección
- ComboBox2 (Disponible) debe tener una selección

---

#### Limpiar()

```csharp
public void Limpiar()
{
    textBox1.Clear();
    textBox2.Clear();
    textBox3.Clear();
    textBox4.Clear();
    textBox5.Clear();

    comboBox1.SelectedIndex = -1;
    comboBox2.SelectedIndex = -1;
}
```

**Descripción**: Limpia todos los campos del formulario.  
**Uso**: Se utiliza después de una operación exitosa o al hacer clic en el botón "Limpiar".

---

### 8.3 Eventos del Formulario

#### button1_Click() - Agregar Plato

```csharp
private void button1_Click(object sender, EventArgs e)
{
    try
    {
        if (Validar())
        {
            TListaPlato.Insert(CrearObjeto());
            Listar();
            Limpiar();
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

**Descripción**: Valida los datos, crea un nuevo plato e lo inserta en la lista.

---

#### button2_Click() - Actualizar Plato

```csharp
private void button2_Click(object sender, EventArgs e)
{
    try
    {
        if (dataGridView1.CurrentRow != null)
        {
            int pos = dataGridView1.CurrentRow.Index;
            TListaPlato.Update(pos, CrearObjeto());
            Listar();
            Limpiar();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

**Descripción**: Obtiene la posición del plato seleccionado, lo actualiza con los nuevos datos, y refresca la lista.

---

#### button3_Click() - Eliminar Plato

```csharp
private void button3_Click(object sender, EventArgs e)
{
    try
    {
        if (dataGridView1.CurrentRow != null)
        {
            DialogResult r = MessageBox.Show(
                "¿Desea eliminar el plato?",
                "Eliminar",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                int pos = dataGridView1.CurrentRow.Index;
                TListaPlato.Delete(pos);
                Listar();
                Limpiar();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

**Descripción**: Pide confirmación al usuario antes de eliminar, y si confirma, elimina el plato seleccionado.

---

#### button4_Click() - Limpiar Formulario

```csharp
private void button4_Click(object sender, EventArgs e)
{
    Limpiar();
}
```

**Descripción**: Limpia todos los campos del formulario.

---

#### dataGridView1_CellClick() - Seleccionar Plato

```csharp
private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
{
    int pos = e.RowIndex;

    if (pos >= 0)
    {
        Plato p = TListaPlato.GetPlato(pos);

        textBox1.Text = p.Id.ToString();
        textBox2.Text = p.Nombre;
        textBox3.Text = p.Descripcion;
        textBox4.Text = p.Precio.ToString();
        textBox5.Text = p.Stock.ToString();
        // ... carga la categoría y disponibilidad
    }
}
```

**Descripción**: Al hacer clic en una fila del DataGridView, carga los datos del plato seleccionado en los campos del formulario para permitir su edición.

---

#### frmPlatos_Load() - Cargar Formulario

```csharp
private void frmPlatos_Load(object sender, EventArgs e)
{
    Listar();
}
```

**Descripción**: Al abrir el formulario, carga la lista de platos en el DataGridView.

---

## 9. Relaciones con Otras Entidades

### 9.1 Relación con Pedido

La relación más importante de **Plato** es con la entidad **Pedido**:

```csharp
public class Pedido
{
    private Plato plato;
    public Plato Plato { get => plato; set => plato = value; }
    
    // ... otros atributos ...
}
```

**Características**:
- Cada pedido está asociado con un plato específico
- El precio del pedido se calcula en función del precio del plato y la cantidad ordenada
- Cuando se crea un pedido, el stock del plato se reduce automáticamente

**Ejemplo en el flujo de pedidos** (`frmPedidos.cs`):

```csharp
public void Calcular()
{
    Plato plato = (Plato)comboBox4.SelectedItem;
    int cantidad = int.Parse(textBox2.Text);
    decimal subtotal = plato.Precio * cantidad;  // Usa el precio del plato
    decimal iva = subtotal * 0.15m;
    decimal total = subtotal + iva;
    
    textBox3.Text = subtotal.ToString();
    textBox4.Text = iva.ToString();
    textBox5.Text = total.ToString();
}
```

### 9.2 Relación con TListaPlato

La clase controladora `TListaPlato` mantiene una lista estática de todos los platos:

```csharp
public static List<Plato> Lista = new List<Plato>();
```

Esta lista es accedida desde:
- **frmPlatos**: Para mostrar, crear, actualizar y eliminar platos
- **frmPedidos**: Para cargar el ComboBox de platos disponibles
- **frmMenu**: Para cargar los platos iniciales del sistema

---

## 10. Funcionamiento dentro del Sistema

### 10.1 Flujo de Inicialización

1. **Carga de Datos** (`frmMenu.CargarDatos()`):
   - Al iniciar la aplicación, se crea el menú principal
   - Se limpian todas las listas
   - Se crean instancias de platos y se agregan a `TListaPlato.Lista`:
   
   ```csharp
   TListaPlato.Insert(new Plato(1, "Arroz con Pollo", "Arroz acompañado de pollo", 4.50m, "Plato Fuerte", true, 20));
   TListaPlato.Insert(new Plato(2, "Encebollado", "Encebollado tradicional", 3.75m, "Sopa", true, 15));
   TListaPlato.Insert(new Plato(3, "Jugo de Mora", "Bebida natural", 1.50m, "Bebida", true, 30));
   ```

2. **Acceso desde el Menú**:
   El usuario selecciona la opción "Platos" del menú principal para abrir `frmPlatos`

### 10.2 Ciclo de Vida de un Plato en la Aplicación

```
1. CREACIÓN
   ↓
   Usuario ingresa datos en frmPlatos y hace clic en "Agregar"
   ↓
2. ALMACENAMIENTO
   ↓
   El plato se agrega a TListaPlato.Lista (en memoria)
   ↓
3. VISUALIZACIÓN
   ↓
   El plato aparece en el DataGridView de frmPlatos
   ↓
4. ASOCIACIÓN CON PEDIDOS
   ↓
   El plato está disponible en el ComboBox de frmPedidos
   ↓
5. USO EN PEDIDOS
   ↓
   Al crear un pedido, se selecciona el plato
   Se calcula el precio: Precio × Cantidad
   Se reduce el stock: Stock = Stock - Cantidad
   ↓
6. ACTUALIZACIÓN
   ↓
   Usuario puede modificar los datos del plato en frmPlatos
   ↓
7. ELIMINACIÓN (Opcional)
   ↓
   Usuario puede eliminar el plato de la lista
```

### 10.3 Interacción con Pedidos

Cuando se crea un pedido en `frmPedidos.cs`:

```csharp
private void button1_Click(object sender, EventArgs e)
{
    try
    {
        if (Validar())
        {
            Pedido p = CrearObjeto();
            
            // Se reduce el stock del plato automáticamente
            p.Plato.DisminuirStock(p.Cantidad);
            
            TListaPedido.Insert(p);
            Listar();
            Limpiar();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

**Pasos**:
1. Se selecciona un plato del ComboBox
2. Se ingresa la cantidad deseada
3. Se calcula automáticamente:
   - Subtotal = Precio del Plato × Cantidad
   - IVA = Subtotal × 0.15 (15%)
   - Total = Subtotal + IVA
4. Se crea el pedido
5. Se reduce el stock del plato en la cantidad pedida
6. El pedido se agrega a la lista

---

## 11. Características Clave

### 11.1 Gestión de Disponibilidad

El plato puede cambiar su estado de disponibilidad sin ser eliminado:

```csharp
public void CambiarDisponibilidad()
{
    Disponible = !Disponible;
}
```

Esto permite:
- Mantener el plato en el sistema
- Controlar si está disponible o no para nuevos pedidos
- No perder el historial del plato

### 11.2 Gestión de Stock

El sistema mantiene un control del inventario:

```csharp
public void DisminuirStock(int cantidad)
{
    if (Stock >= cantidad)
    {
        Stock -= cantidad;
    }
}
```

Características:
- Solo se reduce si hay stock suficiente
- Se actualiza automáticamente con cada pedido
- Permite saber cuándo es necesario reordenar

### 11.3 Categorización

Los platos se organizan por categorías:
- **Plato Fuerte**: Comidas principales
- **Sopa**: Sopas
- **Bebida**: Bebidas
- Otras categorías personalizables

### 11.4 Información Detallada

Cada plato mantiene información completa:
- Identificador único
- Nombre descriptivo
- Descripción detallada
- Precio
- Categoría
- Estado de disponibilidad
- Stock disponible

---

## 12. Almacenamiento de Datos

### 12.1 Estructura de Almacenamiento

Los platos se almacenan en una lista estática en memoria:

```csharp
public static List<Plato> Lista = new List<Plato>();
```

**Tipo**: Lista genérica de objetos `Plato`  
**Alcance**: Estático (compartido por toda la aplicación)  
**Duración**: Durante toda la sesión de la aplicación

### 12.2 Acceso a la Lista

La lista se accede desde:
- `TListaPlato` para operaciones CRUD
- `frmPlatos` para la interfaz de usuario
- `frmPedidos` para llenar ComboBox
- `frmMenu` para inicializar datos

---

## 13. Validaciones

### 13.1 Validaciones en el Formulario

En `frmPlatos.cs`:

```csharp
public bool Validar()
{
    return !textBox1.Text.Equals("") &&      // ID no vacío
           !textBox2.Text.Equals("") &&      // Nombre no vacío
           !textBox3.Text.Equals("") &&      // Descripción no vacía
           !textBox4.Text.Equals("") &&      // Precio no vacío
           !textBox5.Text.Equals("") &&      // Stock no vacío
           comboBox1.SelectedIndex >= 0 &&   // Categoría seleccionada
           comboBox2.SelectedIndex >= 0;     // Disponibilidad seleccionada
}
```

### 13.2 Validaciones en el Controlador

En `TListaPlato.cs`:

```csharp
public static void Insert(Plato op)
{
    if (op != null)
        Lista.Add(op);
    else
        MessageBox.Show("Objeto null");
}

public static void Update(int pos, Plato op)
{
    if (pos >= 0 && op != null)
        Lista[pos] = op;
    else
        MessageBox.Show("Posición negativa o objeto null");
}

public static void Delete(int pos)
{
    if (pos >= 0)
        Lista.RemoveAt(pos);
    else
        MessageBox.Show("Posición negativa");
}
```

---

## 14. Ejemplo Completo de Flujo

### Crear un nuevo plato:

```
1. Usuario abre frmPlatos desde el menú
2. Carga el evento frmPlatos_Load() → Listar()
3. Se muestra la lista actual de platos en DataGridView

4. Usuario ingresa datos:
   - ID: 4
   - Nombre: "Ceviche"
   - Descripción: "Ceviche tradicional"
   - Precio: 5.50
   - Categoría: "Plato Fuerte"
   - Disponible: true
   - Stock: 25

5. Usuario hace clic en "Agregar" → button1_Click()
6. Se ejecuta Validar() → Retorna true
7. Se crea objeto: CrearObjeto() → Retorna Plato(4, "Ceviche", ...)
8. Se inserta: TListaPlato.Insert(nuevoPlato)
9. Se refresca: Listar()
10. Se limpian campos: Limpiar()

11. El plato está disponible en frmPedidos para realizar pedidos
```

### Realizar un pedido con ese plato:

```
1. Usuario abre frmPedidos
2. Selecciona "Ceviche" del ComboBox de platos
3. Ingresa cantidad: 2
4. Se calcula:
   - Subtotal = 5.50 × 2 = 11.00
   - IVA = 11.00 × 0.15 = 1.65
   - Total = 11.00 + 1.65 = 12.65

5. Usuario crea el pedido → button1_Click()
6. Se crea objeto Pedido con el Ceviche
7. Se reduce stock: Ceviche.DisminuirStock(2)
   - Stock: 25 → 23

8. Se inserta el pedido: TListaPedido.Insert(pedido)

9. Plato Ceviche ahora tiene stock = 23
```

---

## 15. Resumen

La entidad **Plato** es fundamental en el sistema del restaurante, representando cada uno de los platos disponibles. Mediante la clase controladora `TListaPlato`, se ejecutan todas las operaciones CRUD necesarias. El formulario `frmPlatos` proporciona una interfaz completa para gestionar los platos, mientras que `frmPedidos` utiliza los platos para crear pedidos, reduciendo automáticamente el stock. El sistema mantiene un control completo del inventario, disponibilidad y categorización de cada plato, permitiendo una gestión eficiente del menú del restaurante.
