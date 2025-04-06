f = open('example.txt')
lines = f.readlines()

first_line = lines[0]
number_of_vertex = first_line.count('0') + first_line.count('1')

matrix = []
for i in lines:
    line = list(map(int, i.split()))
    matrix.append(line)

vertices = list(range(1, number_of_vertex + 1))
initial_vertex = int(input(f"Введите начальную вершину из {vertices}: "))
components = []

while vertices:
    component = []
    to_check = [vertices[0]]
    while len(to_check) > 0:
        current = to_check[0]
        del to_check[0]

        if current in vertices:
            vertices.remove(current)
            component.append(current)

            for i in range(number_of_vertex):
                if matrix[current - 1][i] == 1 and (i + 1) in vertices:
                    to_check.append(i + 1)

    components.append(component)
    print(f"Найдена компонента связности: {component}")

print(f"Общее количество компонент связности: {len(components)}")
