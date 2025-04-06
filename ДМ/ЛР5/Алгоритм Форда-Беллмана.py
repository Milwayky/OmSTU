import sys
f = open('example.txt')
lines = f.readlines()
number_of_vertex = len(lines[0].split())

matrix = []
for i in lines:
    line = list(map(int, i.split()))
    matrix.append(line)

start_vertex = int(input(f"Введите начальную вершину (от 1 до {number_of_vertex}): ")) - 1
inf = sys.maxsize
distances = [inf] * number_of_vertex
distances[start_vertex] = 0
previous = [None] * number_of_vertex

for i in range(number_of_vertex - 1):
    for u in range(number_of_vertex):
        for v in range(number_of_vertex):
            weight = matrix[u][v]
            if weight != 0 and distances[u] != inf:
                if distances[u] + weight < distances[v]:
                    distances[v] = distances[u] + weight
                    previous[v] = u

has_negative_cycle = False
for u in range(number_of_vertex):
    for v in range(number_of_vertex):
        weight = matrix[u][v]
        if weight != 0 and distances[u] != inf:
            if distances[u] + weight < distances[v]:
                has_negative_cycle = True
                break

if has_negative_cycle:
    print("В графе обнаружен отрицательный цикл.")
else:
    print("\nВосстановление путей:")
    for end_vertex in range(number_of_vertex):
        if distances[end_vertex] == inf:
            print(f"{start_vertex + 1} -> {end_vertex + 1}: путь не существует")
            continue

        way = []
        current = end_vertex
        while current is not None:
            way.append(current + 1)
            current = previous[current]
        way.reverse()
        print(f"{start_vertex + 1} -> {end_vertex + 1}: " + " -> ".join(map(str, way)) + f"    ({distances[end_vertex]})")
