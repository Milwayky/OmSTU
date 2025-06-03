f = open('example.txt')
lines = f.readlines()
number_of_vertex = len(lines[0].split())

matrix = []
for line in lines:
    row = []
    for x in line.split():
        if x.lower() == 'inf':
            row.append(float('inf'))
        else:
            row.append(int(x))
    matrix.append(row)

inf = float("inf")
columns = []
rows = []
for i in range(len(matrix)):
    rows.append(i+1)
    columns.append(i+1)


edges = []

sum = 0
for n in range(len(matrix) - 1):
    length = len(matrix)

    for i in range(length):
        min_row = min(matrix[i])
        sum += min_row
        for j in range(length):
            matrix[i][j] -= min_row

    min_column_list = [inf] * length

    for i in range(length):
        for j in range(length):
            if matrix[j][i] < min_column_list[i]:
                min_column_list[i] = matrix[j][i]
        sum += min_column_list[i]

    for i in range(length):
        for j in range(length):
            matrix[j][i] -= min_column_list[i]

    min_row_list = [inf] * length
    for i in range(length):
        if matrix[i].count(0) > 1:
            min_row_list[i] = 0
        else:
            min_row_list[i] = min(filter(lambda x: x != 0, matrix[i]))

    min_column_list = [inf] * length
    for i in range(length):
        zero_counter = 0
        for j in range(length):
            if matrix[j][i] == 0:
                zero_counter += 1
            elif matrix[j][i] < min_column_list[i]:
                min_column_list[i] = matrix[j][i]
            if zero_counter > 1:
                min_column_list[i] = 0
                break

    max_value = 0
    max_row, max_column = 0, 0
    for i in range(length):
        for j in range(length):
            if matrix[i][j] == 0:
                zero_coef = min_row_list[i] + min_column_list[j]
                if zero_coef > max_value:
                    max_value = zero_coef
                    max_row, max_column = i, j

    matrix[max_column][max_row] = inf

    edges.append((rows[max_row], columns[max_column]))
    rows.pop(max_row)
    columns.pop(max_column)

    matrix = [
        [val for j, val in enumerate(row) if j != max_column]
        for i, row in enumerate(matrix) if i != max_row
    ]

edges.append((rows[0], columns[0]))
print("Оптимальный путь:", edges)
print("Минимальная стоимость:", sum)

