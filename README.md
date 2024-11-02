# 🔐 PassGen — Генератор паролей для консоли

PassGen — это удобный консольный генератор паролей, позволяющий быстро создавать пароли различной длины и сложности. Программа поддерживает кастомные параметры запуска, включая количество паролей, длину и уровень сложности. Программа полезна для создания сложных и надежных паролей для различных целей.

---

## 🎉 Возможности

- **Генерация паролей различной сложности**:
  - `1` — только цифры.
  - `2` — цифры и буквы.
  - `3` — цифры, буквы и специальные символы.
- **Задание длины пароля** — можно выбрать любую длину для пароля.
- **Массовая генерация** — создавайте сразу несколько паролей.
- **Подсказка по командам** — используйте `-h` или `-help` для вывода справки.

---

## ⚙️ Аргументы командной строки

Используйте параметры для управления программой из консоли:

- `-h` или `-help` — вывод справки с описанием доступных параметров.
- `-d [1-3]` или `-dif [1-3]` — задает **уровень сложности** пароля:
  - `1` — только цифры.
  - `2` — цифры и буквы.
  - `3` — цифры, буквы и специальные символы.
- `-n [число]` или `-num [число]` — количество генерируемых паролей.
- `-l [число]` или `-len [число]` — длина каждого пароля.

---

## 🔧 Примеры использования

### 1. Создать один пароль из 10 символов со сложностью 2 (цифры и буквы):
```bash
passgen -l 10 -d 2
```
### 2. Сгенерировать 5 сложных паролей (длина 16, все символы):
```bash
passgen -n 5 -l 16 -d 3
```
### 3. Получить справку по командам:
```bash
passgen -h
```
