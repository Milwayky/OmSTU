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

matrix_res = matrix
for k in range(number_of_vertex):
    matrix_base = matrix_res
    for i in range(number_of_vertex):
        for j in range(number_of_vertex):
            matrix_res[i][j] = min(matrix_base[i][k] + matrix_base[k][j], matrix_base[i][j])

for row in matrix_res:
    print(" ".join(str(x) if x != float('inf') else 'inf' for x in row))