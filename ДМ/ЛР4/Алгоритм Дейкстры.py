import sys
f = open('example.txt')
lines = f.readlines()
number_of_vertex = len(lines[0].split())

matrix = []
for i in lines:
    line = list(map(int, i.split()))
    matrix.append(line)

start_vertex = int(input(f"Введите начальную вершину (от 1 до {number_of_vertex}): ")) - 1
end_vertex = int(input(f"Введите конечную вершину (от 1 до {number_of_vertex}): ")) - 1
inf = sys.maxsize
distances = [inf] * number_of_vertex
previous = [None] * number_of_vertex
visited = [False] * number_of_vertex
distances[start_vertex] = 0

while True:
    min_distance = inf
    current_vertex = -1
    for i in range(number_of_vertex):
        if not visited[i] and distances[i] < min_distance:
            min_distance = distances[i]
            current_vertex = i

    if current_vertex == -1:
        break
    visited[current_vertex] = True


    for i in range(number_of_vertex):
        if matrix[current_vertex][i] != 0:
            weight = matrix[current_vertex][i]
            new_distance = distances[current_vertex] + weight
            if new_distance < distances[i]:
                distances[i] = new_distance
                previous[i] = current_vertex


if distances[end_vertex] == inf:
    print(f"Невозможно достичь вершину {end_vertex + 1} из вершины {start_vertex + 1}.")
else:
    print(f"Минимальное расстояние от вершины {start_vertex + 1} до вершины {end_vertex + 1}: {distances[end_vertex]}")

    way = []
    current = end_vertex
    while current is not None:
        way.append(current + 1)
        current = previous[current]
    way.reverse()
    print("Путь:", " -> ".join(map(str, way)))
