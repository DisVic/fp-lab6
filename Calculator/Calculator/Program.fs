open System

// Основные арифметические операции
let add x y = x + y
let subtract x y = x - y
let multiply x y = x * y
let divide x y =
    if y = 0.0 then failwith "Ошибка: деление на ноль"
    else x / y

// Дополнительные математические операции
let power x y = Math.Pow(x, y)
let sqrt x =
    if x < 0.0 then failwith "Ошибка: квадратный корень из отрицательного числа"
    else Math.Sqrt(x)

// Функция для преобразования градусов в радианы
let degreesToRadians degrees = degrees * Math.PI / 180.0

// Тригонометрические функции (аргумент в градусах)
let sinDeg x = Math.Sin(degreesToRadians x)
let cosDeg x = Math.Cos(degreesToRadians x)
let tanDeg x =
    if (cosDeg x) = 0.0 then failwith "Ошибка: тангенс не определен для этого угла"
    else Math.Tan(degreesToRadians x)

// Функция для ввода чисел с обработкой исключений
let rec inputNumber prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match Double.TryParse(input) with
    | true, value -> value
    | false, _ ->
        printfn "Ошибка: введено некорректное число. Повторите попытку."
        inputNumber prompt

// Функция для отображения меню и выполнения выбранной операции
let rec calculator () =
    printfn "Выберите операцию:"
    printfn "1. Сложение"
    printfn "2. Вычитание"
    printfn "3. Умножение"
    printfn "4. Деление"
    printfn "5. Возведение в степень"
    printfn "6. Квадратный корень"
    printfn "7. Синус (в градусах)"
    printfn "8. Косинус (в градусах)"
    printfn "9. Тангенс (в градусах)"
    printfn "0. Выход"

    match Console.ReadLine() with
    | "1" ->
        let x = inputNumber "Введите первое число: "
        let y = inputNumber "Введите второе число: "
        printfn "Результат: %f" (add x y)
        printfn " "
        calculator()
    | "2" ->
        let x = inputNumber "Введите первое число: "
        let y = inputNumber "Введите второе число: "
        printfn "Результат: %f" (subtract x y)
        printfn " "
        calculator()
    | "3" ->
        let x = inputNumber "Введите первое число: "
        let y = inputNumber "Введите второе число: "
        printfn "Результат: %f" (multiply x y)
        printfn " "
        calculator()
    | "4" ->
        let x = inputNumber "Введите первое число: "
        let y = inputNumber "Введите второе число: "
        try
            printfn "Результат: %f" (divide x y)
        with
        | ex -> printfn "%s" ex.Message
        printfn " "
        calculator()
    | "5" ->
        let x = inputNumber "Введите основание: "
        let y = inputNumber "Введите показатель: "
        printfn "Результат: %f" (power x y)
        printfn " "
        calculator()
    | "6" ->
        let x = inputNumber "Введите число: "
        try
            printfn "Результат: %f" (sqrt x)
        with
        | ex -> printfn "%s" ex.Message
        printfn " "
        calculator()
    | "7" ->
        let x = inputNumber "Введите угол (в градусах): "
        printfn "Результат: %f" (sinDeg x)
        printfn " "
        calculator()
    | "8" ->
        let x = inputNumber "Введите угол (в градусах): "
        printfn "Результат: %f" (cosDeg x)
        printfn " "
        calculator()
    | "9" ->
        let x = inputNumber "Введите угол (в градусах): "
        try
            printfn "Результат: %f" (tanDeg x)
        with
        | ex -> printfn "%s" ex.Message
        printfn " "
        calculator()
    | "0" ->
        printfn "Выход из программы."
    | _ ->
        printfn "Ошибка: неверный ввод."
        printfn " "
        calculator()

// Запуск калькулятора
calculator()
