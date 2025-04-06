f = open('example.txt')
lines = f.readlines()

number_of_vertex = lines[0].count('0') + lines[0].count('1')

matrix = []
for i in lines:
    line = list(map(int, i.split()))
    matrix.append(line)

vertex_labels = list(range(1, number_of_vertex + 1))

for i in range(number_of_vertex):
    for j in range(number_of_vertex):
        if matrix[i][j] == 1:
            if vertex_labels[i] >= vertex_labels[j]:
                vertex_labels[i] = vertex_labels[j]
            if vertex_labels[j] >= vertex_labels[i]:
                vertex_labels[j] = vertex_labels[i]

components = []
for i in range(1, number_of_vertex + 1):
    component = []
    for j in range(number_of_vertex):
        if vertex_labels[j] == i:
            component.append(j + 1)
    if component:
        components.append(component)

number = 1
for component in components:
    print(f"Компонента {number}: {component}")
    number += 1
