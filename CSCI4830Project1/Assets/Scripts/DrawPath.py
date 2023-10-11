import matplotlib.pyplot as plt

# Read positions from file
positions = []
with open('/Users/hmac/Desktop/path_positions.txt', 'r') as file:
    for line in file.readlines():
        x, z = map(float, line.strip().split(','))
        positions.append((x, z))

# Extract x and z coordinates
x_coords = [pos[0] for pos in positions]
z_coords = [pos[1] for pos in positions]

# Plot the route
plt.plot(x_coords, z_coords, marker='o')
plt.xlabel('X Position')
plt.ylabel('Z Position')
plt.title('Object Route')
plt.grid(True)
plt.show()
