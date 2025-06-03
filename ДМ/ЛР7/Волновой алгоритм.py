f = open('example.txt')
lines = f.readlines()

field = []
for line in lines:
    row = line.strip().split()
    field.append(row)

rows = len(field)
columns = len(field[0])

new_field = [['-1'] * (columns + 2)]
for row in field:
    new_row = ['-1'] + row + ['-1']
    new_field.append(new_row)
new_field.append(['-1'] * (columns + 2))

start_x = int(input("Введите номер столбца начальной точки (от 1): ")) - 1
start_y = int(input("Введите номер строки начальной точки (от 1): ")) - 1

end_x = int(input("Введите номер столбца конечной точки (от 1): ")) - 1
end_y = int(input("Введите номер строки конечной точки (от 1): ")) - 1


step = 0
new_field[start_y + 1][start_x + 1] = str(step)

while True:
    changed = False
    for i in range(1, rows + 1):
        for j in range(1, columns + 1):
            if new_field[i][j] == str(step):
                # вверх
                if new_field[i - 1][j] == '.':
                    new_field[i - 1][j] = str(step + 1)
                    changed = True
                # вниз
                if new_field[i + 1][j] == '.':
                    new_field[i + 1][j] = str(step + 1)
                    changed = True
                # влево
                if new_field[i][j - 1] == '.':
                    new_field[i][j - 1] = str(step + 1)
                    changed = True
                # вправо
                if new_field[i][j + 1] == '.':
                    new_field[i][j + 1] = str(step + 1)
                    changed = True
    step += 1
    if new_field[end_y + 1][end_x + 1].isdigit():
        print(f"Кратчайший путь: {new_field[end_y + 1][end_x + 1]}")
        break
    if not changed:
        print("Путь не найден.")
        break

